// SPDX-License-Identifier: AGPL-3.0-only

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using GameTranslator.Core;

namespace GameTranslator.App.Services;

/// <summary>
/// Windows'ta Chiaki veya PlayStation Remote Play pencerelerini güvenle yakalayan servis.
/// Sadece uzaktan oynatma süreçlerine ait pencereleri yakalar, masaüstü veya dosya gezgini pencerelerini ASLA yakalamaz.
/// </summary>
public static class WindowCaptureService
{
    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll")]
    private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    private static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

    [DllImport("user32.dll")]
    private static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, uint nFlags);

    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

    [DllImport("gdi32.dll")]
    private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

    [DllImport("gdi32.dll")]
    private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

    [DllImport("gdi32.dll")]
    private static extern bool DeleteDC(IntPtr hdc);

    [DllImport("gdi32.dll")]
    private static extern bool DeleteObject(IntPtr hObject);

    [DllImport("gdi32.dll")]
    private static extern int GetDIBits(IntPtr hdc, IntPtr hbmp, uint uStartScan, uint cScanLines, byte[] lpvBits, ref BITMAPINFO lpbi, uint uUsage);

    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);

    private const int SM_CXSCREEN = 0;
    private const int SM_CYSCREEN = 1;
    private const int SRCCOPY = 0x00CC0020;
    private const int DIB_RGB_COLORS = 0;
    private const int BI_RGB = 0;
    private const uint PW_RENDERFULLCONTENT = 0x00000002;
    private const int SW_RESTORE = 9;
    private const int SW_SHOWNOACTIVATE = 4;
    private const int GWL_EXSTYLE = -20;
    private const int WS_EX_TOOLWINDOW = 0x00000080;
    private const int WS_EX_LAYERED = 0x00080000;
    private const int WS_EX_NOACTIVATE = 0x08000000;
    private const uint LWA_ALPHA = 0x00000002;
    private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
    private const uint SWP_NOSIZE = 0x0001;
    private const uint SWP_NOMOVE = 0x0002;
    private const uint SWP_NOACTIVATE = 0x0010;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    private static readonly HashSet<string> RemotePlayProcessNames = new(StringComparer.OrdinalIgnoreCase)
    {
        "chiaki",
        "chiaki-ng",
        "RemotePlay",
        "PlayStationRemotePlay"
    };

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public int Width => Right - Left;
        public int Height => Bottom - Top;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct POINT
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct BITMAPINFOHEADER
    {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct BITMAPINFO
    {
        public BITMAPINFOHEADER bmiHeader;
        public uint bmiColors;
    }

    public static void MakeInvisibleBackground(IntPtr hWnd)
    {
        try
        {
            if (hWnd == IntPtr.Zero) return;

            // 1. Taskbar'dan gizle (ToolWindow) ve şeffaf yap (Layered Window + Alpha 1)
            int exStyle = GetWindowLong(hWnd, GWL_EXSTYLE);
            int newExStyle = exStyle | WS_EX_TOOLWINDOW | WS_EX_LAYERED | WS_EX_NOACTIVATE;
            if (exStyle != newExStyle)
            {
                SetWindowLong(hWnd, GWL_EXSTYLE, newExStyle);
            }
            SetLayeredWindowAttributes(hWnd, 0, 1, LWA_ALPHA);

            // 2. Eğer simge durumunda kaldıysa sessizce aç (kullanıcıya odak vermeden karesini renderlasın)
            if (IsIconic(hWnd))
            {
                ShowWindow(hWnd, SW_SHOWNOACTIVATE);
            }

            // 3. En arkaya gönder (HWND_BOTTOM), boyutu ve konumu bozma, odak çalma
            SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
        }
        catch { }
    }

    public static void RestoreAndActivate(IntPtr hWnd)
    {
        // Geriye uyumluluk için Chiaki'yi ekrana fırlatmak yerine arka planda gizler
        MakeInvisibleBackground(hWnd);
    }

    /// <summary>
    /// Sadece Chiaki veya Sony Remote Play süreçlerine ait açık oyun pencerelerini arar.
    /// Explorer, tarayıcı veya masaüstü pencerelerini asla hedef olarak seçmez.
    /// </summary>
    public static IntPtr FindTargetWindow(out string windowTitle)
    {
        IntPtr found = IntPtr.Zero;
        string foundTitle = string.Empty;
        int bestScore = -1;

        EnumWindows((hWnd, _) =>
        {
            try
            {
                if (!IsWindowVisible(hWnd) || IsIconic(hWnd)) return true;

                GetWindowThreadProcessId(hWnd, out var pid);
                if (pid == 0 || pid == Environment.ProcessId) return true;

                string procName;
                try
                {
                    using var proc = Process.GetProcessById((int)pid);
                    procName = proc.ProcessName;
                }
                catch
                {
                    return true;
                }

                // Sadece yetkili PS Remote Play süreçlerini kabul et
                if (!RemotePlayProcessNames.Contains(procName)) return true;

                if (!GetClientRect(hWnd, out var rect) || rect.Width < 250 || rect.Height < 150)
                    return true;

                var sb = new StringBuilder(256);
                GetWindowText(hWnd, sb, 256);
                var title = sb.ToString();

                // Yayın/oyun penceresine öncelik ver
                int score = 10;
                if (title.Contains("Stream", StringComparison.OrdinalIgnoreCase)) score += 50;
                if (title.Contains("PlayStation", StringComparison.OrdinalIgnoreCase)) score += 30;
                if (title.Contains("PS5", StringComparison.OrdinalIgnoreCase)) score += 30;
                if (rect.Width >= 1200 || rect.Height >= 700) score += 20;

                if (score > bestScore)
                {
                    bestScore = score;
                    found = hWnd;
                    foundTitle = string.IsNullOrWhiteSpace(title) ? procName : title;
                }
            }
            catch { }

            return true;
        }, IntPtr.Zero);

        windowTitle = foundTitle;
        return found;
    }

    /// <summary>
    /// Hedef Chiaki veya Remote Play penceresinin görüntüsünü BGRA Frame olarak yakalar.
    /// Pencere bulunamazsa veya geçersizse null döner; masaüstünü ASLA yakalamaz.
    /// </summary>
    public static Frame? Capture(IntPtr hWnd)
    {
        if (hWnd == IntPtr.Zero) return null;

        try
        {
            if (!IsWindowVisible(hWnd) || IsIconic(hWnd)) return null;

            if (!GetClientRect(hWnd, out var rect) || rect.Width < 100 || rect.Height < 100)
                return null;

            var pt = new POINT();
            ClientToScreen(hWnd, ref pt);
            int srcX = pt.X;
            int srcY = pt.Y;
            int width = rect.Width;
            int height = rect.Height;

            int screenW = GetSystemMetrics(SM_CXSCREEN);
            int screenH = GetSystemMetrics(SM_CYSCREEN);
            if (width <= 0 || height <= 0 || srcX >= screenW || srcY >= screenH) return null;

            IntPtr srcDc = GetDC(IntPtr.Zero);
            if (srcDc == IntPtr.Zero) return null;

            IntPtr memDc = CreateCompatibleDC(srcDc);
            IntPtr hBitmap = CreateCompatibleBitmap(srcDc, width, height);
            IntPtr oldBmp = SelectObject(memDc, hBitmap);

            bool captured = false;
            try
            {
                captured = PrintWindow(hWnd, memDc, PW_RENDERFULLCONTENT);
            }
            catch { }

            if (!captured)
            {
                try
                {
                    captured = PrintWindow(hWnd, memDc, 0);
                }
                catch { }
            }

            var bi = new BITMAPINFO
            {
                bmiHeader = new BITMAPINFOHEADER
                {
                    biSize = (uint)Marshal.SizeOf<BITMAPINFOHEADER>(),
                    biWidth = width,
                    biHeight = -height, // top-down
                    biPlanes = 1,
                    biBitCount = 32,
                    biCompression = BI_RGB
                }
            };

            var pixels = new byte[width * height * 4];
            GetDIBits(memDc, hBitmap, 0, (uint)height, pixels, ref bi, DIB_RGB_COLORS);

            // Eğer PrintWindow tamamen siyah piksel verdiyse (DirectX/OpenGL pencerelerinde yaygın)
            // ve pencere ekranda görünüyorsa doğrudan ekran DC'sinden BitBlt yap
            if (IsFrameBlack(pixels, width, height) && srcX >= 0 && srcY >= 0 && srcX + width <= screenW && srcY + height <= screenH)
            {
                BitBlt(memDc, 0, 0, width, height, srcDc, srcX, srcY, SRCCOPY);
                GetDIBits(memDc, hBitmap, 0, (uint)height, pixels, ref bi, DIB_RGB_COLORS);
            }

            SelectObject(memDc, oldBmp);
            DeleteObject(hBitmap);
            DeleteDC(memDc);
            ReleaseDC(IntPtr.Zero, srcDc);

            if (IsFrameBlack(pixels, width, height))
            {
                return null;
            }

            return new Frame(pixels, width, height, width * 4);
        }
        catch
        {
            return null;
        }
    }

    private static bool IsFrameBlack(byte[] pixels, int width, int height)
    {
        if (pixels == null || pixels.Length < 16) return true;
        int step = Math.Max(1, (width * height) / 40);
        for (int i = 0; i < width * height; i += step)
        {
            int idx = i * 4;
            if (idx + 2 < pixels.Length)
            {
                if (pixels[idx] > 5 || pixels[idx + 1] > 5 || pixels[idx + 2] > 5)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Masaüstünü veya seçili monitörü doğrudan GDI BitBlt ile 1080p/ekran çözünürlüğünde yakalar.
    /// </summary>
    public static Frame? CaptureScreen(int x = 0, int y = 0, int width = 1920, int height = 1080)
    {
        int screenW = GetSystemMetrics(SM_CXSCREEN);
        int screenH = GetSystemMetrics(SM_CYSCREEN);
        if (width <= 0 || width > screenW) width = screenW > 0 ? screenW : 1920;
        if (height <= 0 || height > screenH) height = screenH > 0 ? screenH : 1080;

        IntPtr srcDc = GetDC(IntPtr.Zero);
        if (srcDc == IntPtr.Zero) return null;

        try
        {
            IntPtr memDc = CreateCompatibleDC(srcDc);
            IntPtr hBitmap = CreateCompatibleBitmap(srcDc, width, height);
            IntPtr oldBmp = SelectObject(memDc, hBitmap);

            BitBlt(memDc, 0, 0, width, height, srcDc, x, y, SRCCOPY);

            var bi = new BITMAPINFO
            {
                bmiHeader = new BITMAPINFOHEADER
                {
                    biSize = (uint)Marshal.SizeOf<BITMAPINFOHEADER>(),
                    biWidth = width,
                    biHeight = -height,
                    biPlanes = 1,
                    biBitCount = 32,
                    biCompression = BI_RGB
                }
            };

            var pixels = new byte[width * height * 4];
            GetDIBits(memDc, hBitmap, 0, (uint)height, pixels, ref bi, DIB_RGB_COLORS);

            SelectObject(memDc, oldBmp);
            DeleteObject(hBitmap);
            DeleteDC(memDc);
            ReleaseDC(IntPtr.Zero, srcDc);

            return new Frame(pixels, width, height, width * 4);
        }
        catch
        {
            ReleaseDC(IntPtr.Zero, srcDc);
            return null;
        }
    }

    /// <summary>
    /// Başlığı veya alt dizesi eşleşen herhangi bir açık pencereyi bulur (ör. OBS Studio, Projector vb.).
    /// </summary>
    public static IntPtr FindWindowBySubstring(string substring)
    {
        if (string.IsNullOrWhiteSpace(substring)) return IntPtr.Zero;
        IntPtr found = IntPtr.Zero;

        EnumWindows((hWnd, _) =>
        {
            try
            {
                if (!IsWindowVisible(hWnd) || IsIconic(hWnd)) return true;
                GetWindowThreadProcessId(hWnd, out var pid);
                if (pid == 0 || pid == Environment.ProcessId) return true;

                var sb = new StringBuilder(256);
                GetWindowText(hWnd, sb, 256);
                var title = sb.ToString();

                if (title.Contains(substring, StringComparison.OrdinalIgnoreCase))
                {
                    found = hWnd;
                    return false;
                }
            }
            catch { }
            return true;
        }, IntPtr.Zero);

        return found;
    }

    /// <summary>
    /// Kullanıcının seçebileceği açık pencerelerin başlık listesini döndürür.
    /// </summary>
    public static IReadOnlyList<string> GetTopLevelWindowTitles()
    {
        var list = new List<string>();
        try
        {
            EnumWindows((hWnd, _) =>
            {
                try
                {
                    if (!IsWindowVisible(hWnd) || IsIconic(hWnd)) return true;
                    GetWindowThreadProcessId(hWnd, out var pid);
                    if (pid == 0 || pid == Environment.ProcessId) return true;

                    if (!GetClientRect(hWnd, out var rect) || rect.Width < 300 || rect.Height < 200)
                        return true;

                    var sb = new StringBuilder(256);
                    GetWindowText(hWnd, sb, 256);
                    var title = sb.ToString().Trim();

                    if (!string.IsNullOrWhiteSpace(title) && !list.Contains(title))
                    {
                        list.Add(title);
                    }
                }
                catch { }
                return true;
            }, IntPtr.Zero);
        }
        catch { }

        return list;
    }
}
