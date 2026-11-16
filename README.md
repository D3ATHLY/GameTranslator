# 🎮 GameTranslator v1.6 Pro
### Konsol ve PC Oyunları İçin Gerçek Zamanlı, Sıfır Gecikmeli Türkçe Altyazı ve Hazır Yama Sistemi

[![Platform: macOS](https://img.shields.io/badge/Platform-macOS%20%7C%20Windows-blue?style=flat-square&logo=apple)](https://gitlab.com/sefflex/GameTranslator)
[![Target: Smart TV & Second Screen](https://img.shields.io/badge/Hedef-Smart%20TV%20%7C%20İkinci%20Ekran-green?style=flat-square&logo=android)](https://gitlab.com/sefflex/GameTranslator)
[![Console: PS5 & Xbox](https://img.shields.io/badge/Konsol-PS5%20%7C%20Xbox-purple?style=flat-square&logo=xbox)](https://gitlab.com/sefflex/GameTranslator)
[![Zero-Lag](https://img.shields.io/badge/Gecikme-0%20ms%20(Doğrudan%20HDMI)-brightgreen?style=flat-square)](#-temel-mantık-3-cümlede-nasıl-çalışıyor)
[![Version](https://img.shields.io/badge/Sürüm-v1.6.6-brightgreen?style=flat-square)](https://gitlab.com/sefflex/GameTranslator/-/releases/v1.6.6)
[![License: AGPL-3.0](https://img.shields.io/badge/Lisans-AGPL--3.0-red?style=flat-square)](LICENSE)

![GameTranslator Native UI](docs/screenshots/gametranslator-ui.jpg)

**GameTranslator**, başta **GTA V, Red Dead Redemption 2 ve Elden Ring** olmak üzere Türkçe dil desteği bulunmayan **PlayStation 5 ve Xbox** konsol oyunlarını veya PC yapımlarını; televizyonunuzda veya ikinci ekranınızda **sıfır gecikmeyle (0 input lag)**, **4K 120 FPS / HDR görüntü kalitesi zerre bozulmadan** Türkçe altyazıyla oynamanızı sağlayan açık kaynaklı sistemdir.

---

## ⚡ v1.6.6 — Son Güncellemeler ve Yenilikler

* 📱 **QR Kodlu İkinci Ekran (Second Screen Companion):**  
  Monitörde oyun oynayanlar veya Smart TV'sine uygulama kuramayanlar için! Bilgisayarınızdaki yerel sunucu üzerinden (`/ekran`) çalışan, internet gerektirmeyen canlı altyazı sayfası. **Ayarlar > Bağlantı** altındaki QR kodu telefonunuz veya tabletinizle taratıp ekranın önüne koyarak altyazıları büyük puntolarla canlı takip edebilirsiniz.
* 💚 **Doğrudan Xbox Ev Yayını (Beta) Desteği:**  
  Harici pencereye gerek kalmadan, Microsoft cihaz koduyla oturum açarak evinizdeki Xbox konsoluna doğrudan bağlanma (PC & Android Telefon). Şifre uygulamaya gelmez, resmi Microsoft protokolü kullanılır.
* 🖱️ **Fareyle Altyazı Barı Konumlandırma & Boyutlandırma:**  
  **Ayarlar > TV Görünümü > "Altyazıyı Konumlandır"** menüsüyle ekrandaki altyazı kutusunu fareyle köşelerinden tutup boyutlandırabilir, istenen yere taşıyıp çift tıklayarak kalıcı olarak kaydedebilirsiniz (çoklu monitör uyumlu). Uzun satırlarda kutu dinamik genişler.
* 🎨 **Tamamen Yenilenen Modern Arayüz:**  
  Daha sade, akıcı ve tek ekrandan tüm ayarları yönetmeye imkan veren modern tasarım dili.
* 📱 **Android Mobil Uygulaması (Flutter & Kotlin):**  
  Bilgisayara gerek kalmadan telefon üzerinden çeviri yapabilme, 0ms hazır yama kütüphanesi, Xbox WebRTC desteği ve Smart TV'ye tek tıkla kablosuz APK kurma sihirbazı.
* 📺 **Eşzamanlı TV & OBS Desteği:**  
  TV uygulaması ile OBS Browser Source katmanının aynı anda senkronize altyazı alabilmesi.

<details>
<summary><b>📜 Önceki v1.5.0 Yeniliklerini Görüntüle</b></summary>

* 🚀 **Tam Gizli (Headless) PS5 Remote Play:** Chiaki penceresini ekranda açmaya gerek kalmadan, doğrudan arka planda ultra düşük gecikmeli (38ms) yerel akış ve otomatik eşleştirme.
* 🧩 **0 ms Hazır Türkçe Oyun Yamaları:** Final Fantasy VII Remake, Final Fantasy VII Rebirth, GTA V, Red Dead Redemption 2, Elden Ring, Mafia: The Old Country ve Assassin's Creed Shadows için hazır Türkçe oyun yamaları! Oyunu açtığınızda yama kendiliğinden tanınır ve çeviriyi beklemeden anında TV'ye yansıtılır.
* 🎥 **Genişletilmiş Görüntü Kaynağı (Capture Card & OBS):** PS5 Remote Play'in yanı sıra Elgato / USB Capture Card ve doğrudan Masaüstü / OBS canlı akışını seçebilme.
* 🌐 **Dinamik Ağ ve Tak-Çalıştır:** Tüm sabit IP'ler ve geliştirici yolları temizlendi; yerel ağdaki PS5 ve TV'ler otomatik taranıp saniyeler içinde bağlanır.
* 📦 **Modern Windows Kurulum Sihirbazı:** Tek tıkla otomatik kurulum, masaüstü kısayolu ve arka plan güncelleme desteği.
</details>

---

## 🧠 Temel Mantık: 3 Cümlede Nasıl Çalışıyor?

1. **Görüntü TV'de / Monitörde Kalır (0 Lag):** PS5 veya Xbox konsolunuz televizyonunuza veya monitörünüze doğrudan **HDMI kablosuyla** bağlıdır. Oyunun görüntüsü ve sesi doğrudan akar; 4K, 120Hz, HDR kaliteniz aynen korunur, elinizdeki kumanda sıfır gecikmeyle çalışır.
2. **Bilgisayar veya Telefon Sessizce Dinler:** Bilgisayarınız veya Android telefonunuz yerel ağ üzerinden konsola bağlanır (kumandanız TV'den kopmasın diye konsola açtığımız 2. bir hesapla veya Xbox cihaz koduyla bağlanır). Cihazınız sadece görüntüyü okur (OCR) ve İngilizce konuşmaları Türkçeye çevirir.
3. **Ekrana Sadece Altyazı Gider:** Çevrilen Türkçe metin televizyondaki GameTranslator uygulamasına (Android TV, LG webOS, Samsung Tizen) veya **İkinci Ekran** olarak kullandığınız telefon/tablete iletilir; şeffaf bir katmanla orijinal yazının üstüne basılır.

---

## 🖥️ Ortak Yerel Masaüstü Tasarımı (Mac & PC)

GameTranslator, hem **macOS (Apple SwiftUI)** hem de **Windows (WPF / .NET 10)** platformlarında aynı sade, şık ve modern koyu arayüzü sunar. Tarayıcı veya harici web sunucusu gerektirmez.

* **Sol Panel (Çeviri Merkezi / Translation Hub):**
  * **▶ Çeviriyi Başlat / ■ Çeviriyi Durdur:** Canlı sistemi tek tıkla başlatan ve durduran yüksek kontrastlı birincil buton.
  * **Connection Status:** Konsolun ve TV / İkinci Ekran bağlantısının durumunu anlık renkli noktalarla (yeşil/turuncu/gri) bildirir.
  * **🔊 PC Oyun Sesi (Mute / Açık):** Oyunun sesi zaten HDMI kablosuyla televizyonunuzdan geldiği için, bilgisayarınızın hoparlöründen çift ses gelmesini tek tıkla sessize alır (Mute) veya dilediğinizde sesi açar.
  * **Son Altyazı:** Oyunda konuşulan son altyazıyı anlık olarak gösterir ve tek tıkla panoya kopyalama imkanı sunar.

* **Sağ Panel (Entegre Ayarlar & Kalibrasyon Paneli):**
  * **Üst Sekmeler (Segmented Control):** `[ 🖥️ Oyun Okuma Alanı ]`, `[ 📺 TV Görünümü ]`, `[ 🧠 Çeviri & Modeller ]`, `[ 🔗 Bağlantı & Sistem ]`, `[ 📖 Hızlı Rehber ]`.
  * **Oyun Ekranı Altyazı Okuma Alanı:** 16:9 canlı konsol/PC oyun görüntüsü üzerinde mavi kalibrasyon çerçevesiyle alt yazının okunacağı koordinatları belirleme.
  * **Akıllı TV Örtme & Otomatik Yerleşim:** Oyundaki orijinal İngilizce altyazının boyutunu ve koordinatlarını anlık hesaplayarak İngilizce yazıyı kapatır (`İngilizce altyazının üstünü örtsün`), üstüne koyar (`İngilizce altyazının üstünde`) veya altına yerleştirir.
  * **Hassas Kaydırıcılar:** Üst/Alt başlangıç sınırları ve Sol/Sağ sınır ayarları.
  * **Hızlı Seçenekler:** `Alt Orta (Standart)`, `Geniş Alt Bant`, `Tüm Alt Yarı`, `Üst Bölge (Görevler)` ve `Özel Kutu`.
  * **TV & PC Barı Özelleştirme:** Yazı tipi boyutu, alt mesafe oranı, arka plan opaklığı (0-100), köşe yuvarlaklığı, çerçeve genişliği ve Türkçe Dublaj (TTS) desteği.
  * **İkinci Ekran & OBS:** QR kodlu ikinci ekran bağlantısı (`http://<ip>:8787/ekran`) ve yayıncılar için yerel OBS Browser Source overlay bağlantısı (`http://localhost:8787/obs`).

---

## 🎯 Platform Kurulum Rehberi (Hiç Kodlama Bilmeyenler İçin Adım Adım)

> ### 📄 Resimli & Adım Adım TV Kurulum Kılavuzu (PDF)
> Televizyonunuza (Android TV, LG webOS, Samsung Tizen) uygulamanın nasıl kurulacağını anlatan, ekran görüntülü ve detaylı Türkçe rehberimizi doğrudan indirebilirsiniz:
> 👉 **[GameTranslator TV Kurulum Rehberi (PDF)](GameTranslator_TV_Kurulum_Rehberi.pdf)** *(Masaüstünüzde ve bu depoda hazır olarak yer almaktadır)*

Aşağıdaki adımları takip ederek 2 dakika içinde oyunu Türkçe altyazıyla oynamaya başlayabilirsiniz.

---

### 1. 🍏 Mac (macOS Kurulumu - Apple Silicon M1 / M2 / M3 / M4)
> Apple Silicon Neural Engine NPU çipini ve Vision OCR donanımını kullanarak **0 ms gecikmeyle** çevrimdışı çalışır.  
> 💡 **Hızlı İndirme:** [GitLab Sürümler (Releases)](https://gitlab.com/sefflex/GameTranslator/-/releases) sayfasından hazır imzalı **`GameTranslator-macOS-v1.0.0.zip`** dosyasını doğrudan indirebilirsiniz.

#### 🟢 Yöntem A: Hazır Paketi İndirin ve Uygulamalar'a Taşıyın (En Hızlı & Önerilen)
1. **Releases'ten İndirin:** [GitLab Releases](https://gitlab.com/sefflex/GameTranslator/-/releases) sayfasından **`GameTranslator-macOS-v1.0.0.zip`** dosyasını indirin.
2. **Uygulamalar Klasörüne Taşıyın:** İnen ZIP dosyasına çift tıklayarak açın. Çıkan **`GameTranslator.app`** dosyasını Mac'inizin **Uygulamalar (`/Applications`)** klasörüne sürükleyin.
3. **Çift Tıklayıp Başlatın:** Uygulama doğrudan açılır; 5 adımlı yerel kurulum sihirbazı sizi karşılar ve her şeyi otomatik ayarlar!
4. **⚠️ Mac Güvenlik İpuçları (İlk Kez Açarken):**
   * **"Geliştirici doğrulanamadı" uyarısı çıkarsa:**  
     Dosyaya **sağ tıklayın** (veya Control tuşuna basarak tıklayın) ➔ **`Aç`** deyin ve çıkan pencerede tekrar **`Aç`** butonuna basın. (Veya Terminal'de `xattr -cr /Applications/GameTranslator.app` yazmanız yeterlidir).
   * **Ekran Kaydı İzni (Altyazıyı Okumak İçin Şart):**  
     Mac'inizde **`Sistem Ayarları` ➔ `Gizlilik ve Güvenlik` ➔ `Ekran ve Sistem Sesi Kaydı`** bölümünden **`GameTranslator`** anahtarına onay verin.

#### 🛠️ Yöntem B: Kaynak Koddan Tek Tıkla Otomatik Başlatma (`GameTranslator.command`)
Eğer kaynak kodları ZIP veya `git clone` ile indirdiyseniz:
1. Klasörün içindeki **`GameTranslator.command`** dosyasına çift tıklayın.
2. Sistem uygulamanın henüz derlenmediğini otomatik anlar, Apple Developer sertifikanızla imzalar, `/Applications/GameTranslator.app` olarak kurar ve arayüzü başlatır.

---

### 2. 🪟 PC (Windows Yerel Masaüstü Kurulumu - Windows 10 / 11)
> C# / .NET 10, WPF ve DirectML / Windows Media OCR altyapısıyla çalışan yerel, donanım hızlandırmalı Windows masaüstü uygulamasıdır.  
> 💡 **Hızlı İndirme:** [GitLab Sürümler (Releases)](https://gitlab.com/sefflex/GameTranslator/-/releases/v1.6.6) sayfasından güncel kurulum sihirbazını (**`GameTranslator-win-Setup.exe`**) indirebilirsiniz.

#### 🟢 Yöntem A: Hazır Kurulum Sihirbazı ile Tek Tıkla Kurulum (Önerilen)
1. **Releases'ten İndirin:** [GitLab Releases](https://gitlab.com/sefflex/GameTranslator/-/releases/v1.6.6) bölümünden **`GameTranslator-win-Setup.exe`** dosyasını indirin.
2. **Kurulum Sihirbazını Çalıştırın:** **`GameTranslator-win-Setup.exe`** dosyasına çift tıklayın; kurulum otomatik olarak tamamlanır. Kurulu sürümün üstüne kurulabilir; ayarlarınız ve eşleştirmeleriniz korunur.
   * *Neler Yapar:* Gerekli tüm bileşenleri, yerel çeviri ve OCR kütüphanelerini, Xbox köprüsünü kurar, Windows güvenlik izinlerini otomatik ayarlar.
   * *Kısayollar:* Masaüstünüze ve Başlat Menünüze şık `GameTranslator` ikonunu bırakır.
   * *Kaldırma (Uninstall):* İstenildiği zaman Windows *Ayarlar › Yüklü Uygulamalar* (Program Ekle/Kaldır) bölümünden tek tıkla sistemden tertemiz kaldırılabilir.
3. **⚠️ Windows Güvenlik İpuçları (İlk Kez Açarken):**
   * **Windows Defender "Windows kişisel bilgisayarınızı korudu" (SmartScreen) derse:**  
     Mavi penceredeki **`Ek bilgi`** yazısına tıklayın, ardından altta açılan **`Yine de çalıştır`** butonuna basın. (Açık kaynaklı ve dijital imza sertifikası satın alınmamış yeni bağımsız projelerde standarttır, %100 güvenlidir).
   * **Windows Güvenlik Duvarı (Ağ İzni) uyarısı çıkarsa:**  
     Konsolunuzu, TV uygulamasını ve ikinci ekran cihazınızı yerel ağda bulabilmesi için çıkan onay penceresinde **"Özel ağlar (Ev veya iş ağı)"** kutucuğunu işaretleyip **`Erişime izin ver`** butonuna basın.

#### 🛠️ Yöntem B: Kaynak Koddan Tek Tıkla Başlatma veya Derleme (Geliştiriciler)
Eğer kaynak kodları (`ZIP` veya `git clone`) ile indirdiyseniz:
1. **Tek Tıkla Başlatma:** Proje klasöründeki **`GameTranslator.bat`** dosyasına çift tıklayın. Bilgisayarınızdaki .NET SDK ile proje saniyeler içinde derlenir ve açılır.
2. **Tek Tıkla Bağımsız `.exe` Olarak Derlemek:**
   * Klasördeki **`Derle-Windows.bat`** dosyasına çift tıklayın. Sistem tüm projeyi tek parça bağımsız (Self-Contained) Windows uygulaması olarak derler ve `bin/` klasörüne **`GameTranslator.exe`** olarak kaydeder.
3. **💻 Konsoldan Çalıştırma (PowerShell / CMD):**
   ```cmd
   dotnet run --project "windows/src/GameTranslator.App/GameTranslator.App.csproj" -c Release
   ```

---

### 3. 📺 Akıllı TV (Smart TV Companion Uygulamaları)
> TV'niz HDMI'daki oyun görüntüsünü oynatırken, üzerine şeffaf bir OSD penceresi açarak Türkçe altyazıyı basar. Hazır paketler [Releases](https://gitlab.com/sefflex/GameTranslator/-/releases/v1.6.6) sayfasında yer almaktadır.

* **TCL / Google TV / Android TV (Sony, Philips, Xiaomi vb.):**
  * **Hazır Paket Dosyası:** `gametranslator-androidtv_1.0.6.apk`
  * **Kurulum Yöntemi 1 (Telefondan Otomatik - En Pratiği):**  
    GameTranslator Android mobil uygulamasını açın; TV Kurulum Sihirbazı evinizdeki Android TV'yi Wi-Fi üzerinden otomatik bulur ve tek tıkla kurar.
  * **Kurulum Yöntemi 2 (USB ile):**  
    APK dosyasını USB flash belleğe kopyalayıp TV'nize takın ve TV'deki dosya yöneticisiyle kurun.
  * **Kurulum Yöntemi 3 (Wi-Fi / ADB ile):**  
    ```bash
    adb connect <TV-IP-ADRESI>
    adb install gametranslator-androidtv_1.0.6.apk
    ```
* **LG TV (webOS):**
  * **Hazır Paket Dosyası:** `com.gametranslator.tv_1.0.6_all.ipk`
  * **Yöntem 1 (Kalıcı Uygulama - Önerilen):**  
    1. LG TV'nizden LG Content Store'u açıp ücretsiz **"Developer Mode"** uygulamasını kurun ve oturum açın.
    2. Bilgisayarınıza ücretsiz **[webOS Dev Manager](https://github.com/webosbrew/dev-manager-desktop/releases)** indirin ve TV'nizin IP adresini girip bağlanın.
    3. `com.gametranslator.tv_1.0.6_all.ipk` paketini webOS Dev Manager'a sürükleyip TV'ye kurun. TV'de uygulamayı açın.
  * **Yöntem 2 (Sıfır Kurulum - En Hızlı Yol - TV Web Tarayıcısı):**  
    1. LG TV kumandasından **Web Tarayıcısı** uygulamasını açın.
    2. Adres çubuğuna: `http://<BILGISAYAR-IP-ADRESI>:8787` yazın ve tam ekran yapın.
* **Samsung TV (Tizen):**
  * **Hazır Paket Dosyası:** `gametranslator-samsung_1.0.6.wgt`
  * **Yöntem 1 (Apps2Samsung ile Kurulum):**  
    1. TV'de Geliştirici Modunu açın (Uygulamalar menüsünde kumandadan `1-2-3-4-5` tuşlayarak).
    2. Bilgisayarınızda **Apps2Samsung** programını açıp TV IP'nizi girin.
    3. `gametranslator-samsung_1.0.6.wgt` dosyasını seçip **Install** butonuna basın ve TV'de uygulamayı açın.
  * **Yöntem 2 (TV Web Tarayıcısı):**  
    1. Samsung TV'nin web tarayıcısından `http://<BILGISAYAR-IP-ADRESI>:8787` adresini girin ve tam ekran yapın.

---

### 4. 📱 İkinci Ekran & Mobil Uygulama (Android / iOS Companion)

* 📲 **GameTranslator Android Uygulaması (`GameTranslator-mobil-arm64.apk`):**
  * Telefonunuzu bağımsız bir konsol çeviriciye dönüştürür.
  * PS5 ve Xbox konsollarını doğrudan destekler.
  * Dahili 0ms Türkçe yama kütüphanesi içerir.
  * Telefondan Android TV'ye tek tıkla TV uygulaması kurabilir.
* 📱 **İkinci Ekran (QR Kod ile Monitör / TV'siz Kullanım):**
  * Televizyonu desteklenmeyenler veya monitörde oynayanlar için idealdir.
  * Bilgisayarda **Ayarlar > Bağlantı** altındaki QR kodu telefon veya tabletinizle okutun.
  * Cihazınızı ekranınızın önüne yerleştirin; oyun altyazıları telefon/tablet ekranınızda büyük puntolarla canlı olarak aksın!
  * Doğrudan tarayıcı linki: `http://<BILGISAYAR-IP-ADRESI>:8787/ekran`

---

## 🎮 Konsol Bağlantı Ayarları

### 🔵 PlayStation 5 Ayarı (Kumanda Neden Kopmaz?)
PlayStation normalde Remote Play açılınca elinizdeki kumandayı televizyondan koparır. Bunu aşmak son derece basittir:
1. PS5'te `Ayarlar` ➔ `Sistem` ➔ `Uzaktan Oynatma (Remote Play)` ➔ **Uzaktan Oynatmayı Etkinleştir** seçeneğini **AÇIK** yapın.
2. PS5'inizde **ücretsiz ikinci bir kullanıcı / PSN hesabı** ekleyin (örneğin: `oyunceviri@gmail.com`).
3. **Nasıl Oynayacaksınız?**
   - TV karşısında **kendi ana hesabınızı** açıp kumandanızı elinize alın.
   - Bilgisayar ise arka planda bu **ikinci hesapla** konsola bağlanır.
   - Böylece DualSense kumandanız TV'den **asla kopmaz**!

### 🟢 Xbox Ayarı (Series X|S & Xbox One)
Xbox desteği resmi Microsoft cihaz kodu altyapısını kullanır:
1. PC uygulamasında **Ayarlar > Bağlantı > Xbox** bölümüne gidin.
2. **"Microsoft hesabıyla giriş yap"** butonuna tıklayın; ekranda beliren cihaz kodunu tarayıcıda açılan resmi Microsoft sayfasında onaylayın.
3. Hesabınıza bağlı konsolu seçin ve **"Çeviriyi Başlat"** butonuna basın.
4. Sistem arka planda konsolunuza doğrudan bağlanır, harici pencere açılmaz ve şifreleriniz asla uygulamaya kaydedilmez.

---

## 🧠 Hangi Çeviri Modeli Ne İşe Yarar?

| Model | Nasıl Çalışır? | Ne Zaman Tercih Edilmeli? |
| :--- | :--- | :--- |
| **🎮 Hazır Oyun Yaması & Topluluk Paketi** | Oyunun orijinal Türkçe yama metinlerini (`.json` / `.txt` / `.srt`) doğrudan eşler. | **0 ms gecikme ve %100 profesyonel insan çevirisi kalitesi sağlar.** Topluluk yamaları veya el çevirileri için kullanılır. Yamada olmayan ara cümleleri otomatik yapay zekayla tamamlar. |
| **1. Apple Yerel (NPU)** | Mac'inizin Neural Engine (NPU) yapay zeka çipini kullanır. | **0 ms gecikme sağlar.** Tamamen internetsiz, çevrimdışı, kotasız ve ücretsizdir. |
| **2. Google Gemini 2.5 Flash** | Google Gemini API (AI Studio). | GTA 6 gibi oyunlardaki **sokak argosu, küfürler, şakalar ve hikaye bağlamını** en zeki ve en doğal Türkçeyle çeviren yapay zeka modelidir. |
| **3. DeepL API** | DeepL Free / Pro API. | Dünyanın en bilinen profesyonel çeviri motorudur. Kusursuz dilbilgisi için tercih edilir. |
| **4. Yerel Derin Öğrenme** | Bilgisayarınızın CPU/GPU'sunda yerel çalışan MarianMT / DirectML sinir ağı modeli. | İnternetsiz yerel yapay sinir ağı çevirisi. |

---

## 🎮 Topluluk Oyun Yamaları (Community Game Patches)

GameTranslator, fan çeviri gruplarının veya topluluk üyelerinin hazırladığı hazır yama dosyalarını (`.json`, `.txt`, `.srt`) ve GamePack formatlarını doğrudan destekler. Uygulama hem `yamalar/` hem de `patches/` klasörlerini otomatik olarak tarar.

### 📦 Depoda Hazır Bulunan Yamalar (12 Oyun - 629.000+ Replik):
* **Grand Theft Auto V:** `yamalar/gta-v.json` (190.566 satır - TechnoGame + Claude Haiku)
* **Red Dead Redemption 2:** `yamalar/red-dead-redemption-2.json` (195.430 satır - Tam Oyun)
* **Call of Duty: Modern Warfare (2019):** `yamalar/call-of-duty-modern-warfare-2019.json` (51.147 satır)
* **Assassin's Creed Shadows:** `yamalar/assassins-creed-shadows.json` (39.615 satır)
* **Elden Ring + Shadow of the Erdtree:** `yamalar/elden-ring.json` (37.951 satır)
* **Final Fantasy VII Rebirth:** `yamalar/final-fantasy-vii-rebirth.json` (33.238 satır)
* **Watch Dogs:** `yamalar/watch-dogs.json` (25.768 satır)
* **Death Stranding 2: On the Beach:** `yamalar/death-stranding-2.json` (23.132 satır)
* **Mafia: The Old Country:** `yamalar/mafia-the-old-country.json` (18.064 satır)
* **Final Fantasy VII Remake:** `yamalar/final-fantasy-vii-remake.json` (5.758 satır + Fuzzy İndeks)
* **Marvel's Spider-Man 2:** `yamalar/marvels-spider-man-2.json` (2.349 satır)
* **Death Stranding Director's Cut:** `yamalar/death-stranding-directors-cut.json` (1.334 satır)

* 📁 Hazır oyun yamaları için proje ana dizinindeki [`yamalar/`](yamalar/) veya [`patches/`](patches/) klasörlerini inceleyebilirsiniz.
* 🌐 Yamaları bağımsız olarak takip etmek veya indirmek için: **[GitLab Yamalar Deposu](https://gitlab.com/sefflex/yamalar)**
* 🛠️ Kendi yama dökümlerinizi GameTranslator formatına dönüştürmek için [`scripts/patch_converter.py`](scripts/patch_converter.py) aracını kullanabilirsiniz.
* 🤝 **Yamalara Katkı Sağlama:** Kendi hazırladığınız Türkçe yamaları `patches/` veya `yamalar/` klasörüne ekleyip Merge Request açarak tüm oyuncularla paylaşabilir veya mevcut yamalardaki hataları düzenleyebilirsiniz.

---

## 📁 Proje Klasör Rehberi

```text
GameTranslator/
├── yamalar/                        # 🎮 Hazır Türkçe Oyun Yamaları (12 Oyun, 629.000+ Replik - 0ms Eşleme)
│   ├── README.md                   # Yama kataloğu ve detaylı rehber
│   ├── gta-v.json                  # Grand Theft Auto V (190k replik)
│   ├── red-dead-redemption-2.json  # Red Dead Redemption 2 (195k replik)
│   ├── elden-ring.json             # Elden Ring + DLC (38k replik)
│   ├── assassins-creed-shadows.json# Assassin's Creed Shadows (39k replik)
│   ├── call-of-duty-modern-warfare-2019.json # CoD MW 2019 (51k replik)
│   ├── final-fantasy-vii-rebirth.json # FF7 Rebirth (33k replik)
│   ├── final-fantasy-vii-remake.json  # FF7 Remake (5.7k replik)
│   ├── watch-dogs.json             # Watch Dogs (25k replik)
│   ├── death-stranding-2.json      # Death Stranding 2 (23k replik)
│   ├── mafia-the-old-country.json  # Mafia: The Old Country (18k replik)
│   ├── marvels-spider-man-2.json   # Marvel's Spider-Man 2 (2.3k replik)
│   └── death-stranding-directors-cut.json # Death Stranding Director's Cut (1.3k replik)
│
├── patches/                        # 🎮 Topluluk Oyun Yamaları Deposu (0ms Hazır Türkçe Altyazılar)
│   └── README.md                   # Yama ekleme ve katkı rehberi
│
├── mobile/                         # 📱 Android Mobil Uygulaması (Flutter & Kotlin, WebRTC)
│   ├── android/                    # Android yerel modülleri & TV Kurulum Sihirbazı
│   └── lib/                        # Flutter arayüzü & İkinci Ekran kontrolü
│
├── mac/                            # 🍏 macOS Yerel Uygulaması (SwiftUI, Apple Vision OCR, NPU)
│   ├── NativeApp.swift             # Ana masaüstü arayüzü & altyazı motoru
│   ├── build.sh                    # Tek komutla Apple Developer imzalı derleme aracı
│   ├── project.yml                 # XcodeGen proje dosyası
│   └── GameTranslator/             # Varlıklar, ikonlar ve Info.plist
│
├── windows/                        # 🪟 Windows Yerel Uygulaması (.NET 10, C#, WPF, DirectML)
│   ├── GameTranslator.Windows.slnx # Visual Studio / Rider Çözümü
│   ├── src/                        # Modüller (App, Core, RemotePlay, TvInstall)
│   ├── xbox-bridge/                # Xbox ev yayını köprü servisi (Node/WebRTC)
│   └── native/                     # C/C++ donanım hızlandırma katmanı
│
├── tv/                             # 📺 Akıllı TV Uygulamaları (Companion Apps)
│   ├── android/                    # Android TV & Google TV kaynak kodları (Java/Gradle)
│   ├── webos/                      # LG webOS TV şeffaf altyazı katmanı (HTML5/JS)
│   ├── tizen/                      # Samsung Tizen TV katmanı (Web App)
│   └── packages/                   # Doğrudan TV'ye yüklenebilir hazır derlenmiş paketler:
│       ├── gametranslator-androidtv_1.0.6.apk
│       ├── com.gametranslator.tv_1.0.6_all.ipk
│       └── gametranslator-samsung_1.0.6.wgt
│
├── core/                           # ⚙️ Çekirdek Kütüphane (Ağ, OCR gürültü filtreleme, senkronizasyon)
├── dictionaries/                   # 📚 Oyun sözlükleri (GTA 6 slang & community pack)
├── docs/                           # 📖 Detaylı kurulum rehberleri ve mimari dokümanlar
├── design/                         # 🎨 Vektör logolar, AppIcon ve tasarım bileşenleri
├── scripts/                        # 🛠️ TV paketleme ve derleme otomasyon araçları
│
├── GameTranslator.command          # 🚀 Mac tek tıkla başlatıcı
├── GameTranslator.bat              # 🚀 Windows tek tıkla başlatıcı
├── README.md                       # Açık kaynak proje dokümantasyonu
└── LICENSE                         # AGPL-3.0 Açık Kaynak Lisansı
```

---

## 👨‍💻 Geliştiriciler İçin: Kodları Derleme

```bash
# 🍏 macOS Uygulamasını Derleme (Apple Silicon):
bash mac/build.sh

# 🪟 Windows Projesini Derleme ve Çalıştırma:
dotnet run --project windows/src/GameTranslator.App/GameTranslator.App.csproj -c Release

# 📱 Android Uygulamasını Derleme:
cd mobile/android && ./gradlew assembleRelease

# 📺 Android TV APK'sını Kaynak Kodundan Derleme:
cd tv/android && ./gradlew assembleRelease

# ⚙️ Core Swift Kütüphanesini Derleme:
swift build --package-path core
```

---

## ☕ Projeye Destek Olun

GameTranslator tamamen ücretsiz ve açık kaynaklı kalmaya devam edecektir. Projeyi daha ileriye taşımak, App Store geliştirici hesabı açabilmek ve altyapı/geliştirme süreçlerini desteklemek isterseniz bize bir kahve ısmarlayabilirsiniz:

👉 **[buymeacoffee.com/gametranslator](https://buymeacoffee.com/gametranslator)**

---

## ⚖️ Lisans & Telif Hakkı

Bu proje **[GNU AGPL-3.0](LICENSE)** lisansı altında açık kaynak olarak sunulmaktadır.  
Bu proje Sinan Yorulmaz'ın [CouchSubs](https://github.com/yorulmazsinan/couchsubs) projesinden türetilmiştir, 10 Kasım 2026'dan itibaren geliştirilmiş ve değiştirilmiştir.

* Copyright (C) 2026 Sinan Yorulmaz ([CouchSubs](https://github.com/yorulmazsinan/couchsubs))
* Copyright (C) 2026 Sefflex ([GameTranslator](https://gitlab.com/sefflex/GameTranslator) geliştirmeleri ve değişiklikleri)
* Değerli katkıları ve emekleri için **Emir Kaya**'ya (`@emir-kaya` / `@emrky01`) sonsuz teşekkürler.

Çekirdek ağ ve video yakalama altyapısında açık kaynaklı [chiaki-ng](https://github.com/chiaki-ng/chiaki-ng) projesinin temellerinden de yararlanılmıştır.
