// SPDX-License-Identifier: AGPL-3.0-only

using GameTranslator.Core;
using GameTranslator.RemotePlay;

namespace GameTranslator.App.Services;

/// <summary>
/// Masaüstünü, seçili monitörü veya OBS / Pencereyi yakalayarak kareleri altyazı motoruna aktaran IStreamSession.
/// Capture Card kullanıcıları ve OBS Fullscreen Projector kullananlar için PS5 Remote Play gerektirmez.
/// </summary>
public sealed class DesktopCaptureStreamSession : IStreamSession
{
    public event Action<Frame>? FrameReceived;
    public event Action<SessionState>? StateChanged;
#pragma warning disable CS0067
    public event Action<RegisteredConsole>? ConsoleMoved;
#pragma warning restore CS0067

    private readonly string? targetWindowTitle;
    private readonly int screenIndex;
    private CancellationTokenSource? cts;
    private Task? loopTask;
    private bool running;

    public DesktopCaptureStreamSession(string? targetWindowTitle = null, int screenIndex = 0)
    {
        this.targetWindowTitle = targetWindowTitle;
        this.screenIndex = screenIndex;
    }

    public void Start()
    {
        if (running) return;
        running = true;
        cts = new CancellationTokenSource();
        StateChanged?.Invoke(SessionState.Connecting);

        loopTask = Task.Run(() => CaptureLoopAsync(cts.Token));
    }

    private async Task CaptureLoopAsync(CancellationToken token)
    {
        bool emittedStreaming = false;

        while (running && !token.IsCancellationRequested)
        {
            try
            {
                Frame? frame = null;

                // 1. Eğer özel bir pencere veya OBS seçilmişse pencereyi yakala
                if (!string.IsNullOrWhiteSpace(targetWindowTitle))
                {
                    var hWnd = WindowCaptureService.FindWindowBySubstring(targetWindowTitle);
                    if (hWnd != IntPtr.Zero)
                    {
                        frame = WindowCaptureService.Capture(hWnd);
                    }
                }

                // 2. Özel pencere yoksa veya bulunamadıysa doğrudan masaüstü / ekranı oku
                frame ??= WindowCaptureService.CaptureScreen();

                if (frame != null)
                {
                    if (!emittedStreaming)
                    {
                        emittedStreaming = true;
                        StateChanged?.Invoke(SessionState.Streaming);
                    }
                    FrameReceived?.Invoke(frame);
                }
            }
            catch { }

            try
            {
                await Task.Delay(100, token); // ~10 FPS (Altyazı OCR için ideal hız)
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    public void Stop()
    {
        if (!running) return;
        running = false;
        cts?.Cancel();
        StateChanged?.Invoke(SessionState.Disconnected(DisconnectKind.Stopped));
    }

    public void ReconnectNow()
    {
        if (!running) return;
        Stop();
        Start();
    }

    public void Dispose()
    {
        Stop();
        cts?.Dispose();
    }
}
