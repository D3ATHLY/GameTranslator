# 🎮 GameTranslator Hazır Türkçe Oyun Yamaları

Bu klasör, **GameTranslator** uygulamasının **0 ms gecikmeyle (anında)** televizyona veya ekrana yansıtacağı hazır Türkçe oyun yamalarını barındırır.

GameTranslator motoru hem `yamalar/` hem de `patches/` klasörlerini otomatik olarak tarar. Buradaki JSON sözlükleri sayesinde yapay zeka veya sunucu bekleme süresi olmadan, oyundaki replik görüldüğü anda profesyonel Türkçe çevirisi ekrana basılır.

---

## 📦 Mevcut Hazır Oyun Yamaları

| Oyun | Dosya Adı | Replik / Cümle Sayısı | Dosya Boyutu | Açıklama |
| :--- | :--- | :--- | :--- | :--- |
| **Final Fantasy VII Remake** | `final-fantasy-vii-remake.json` | **11.305** satır | ~1.65 MB | Tüm ana hikaye, yan görevler ve ara sahneler |
| **Final Fantasy VII Rebirth** | `final-fantasy-vii-rebirth.json` | **33.238** satır | ~4.09 MB | Tüm bölümler, yan içerikler, NPC diyalogları ve görevler |

---

## ⚡ 0 ms Eşleme Nasıl Çalışır?

1. **Anında Eşleşme:** OCR ile oyun ekranındaki İngilizce altyazı okunduğunda, GameTranslator önce bu klasördeki JSON sözlüklerini kontrol eder.
2. **Karakter ve Konuşmacı Desteği:** `Cloud: Line` ve konuşmacısız `Line` formatlarının her ikisi de anında tanınır.
3. **Akıllı Yedek:** Eğer yamada yer almayan rastgele bir NPC fısıltısı veya anlık yan konuşma varsa, GameTranslator bunu arka plandaki yapay zeka motoru (Google Gemini / Apple NPU) ile anında tamamlar.

---

## 📂 Dosya Formatı (Düz Sözlük JSON)

```json
{
  "Get back!": "Geri çekil!",
  "What is that thing?": "O şey de ne?",
  "Barret: Move it!": "Barret: Kıpırda!"
}
```

---

## 🌐 Harici Yama Deposu

Sadece yamaları takip etmek veya projeyi klonlamadan yamaları bağımsız olarak indirmek isterseniz:
👉 **[GitLab Yamalar Deposu](https://gitlab.com/sefflex/yamalar)**
