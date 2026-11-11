# 🎮 GameTranslator Topluluk Oyun Yamaları (Community Game Patches)

Bu dizin, **GameTranslator** için topluluk tarafından hazırlanan veya popüler Türkçe yama gruplarının (Psyama, OyunÇeviri, DonanımHaber vb.) metinlerinden uyarlanan **resmi ve topluluk oyun yamalarını** barındırır.

---

## ⚡ Neden Oyun Yaması Modu?

1. **0 ms Gecikme:** Yapay zeka veya sunucu bekleme süresi olmadan, ekranınızdaki İngilizce replik anında %100 profesyonel Türkçe çevirisiyle televizyonunuza basılır.
2. **%100 İnsan Çevirisi Kalitesi:** Oyunu yerelleştiren profesyonel çevirmenlerin replikleri doğrudan kullanılır.
3. **Sıfır API / Kota Tüketimi:** İnternet bağlantısı veya ücretli API gerektirmez.
4. **Hibrit Tamamlama (Yapay Zeka Yedeği):** Yamada henüz yer almayan yan replikler veya rastgele diyaloglar varsa, GameTranslator bunları otomatik olarak Google Gemini / Apple NPU motoru ile anında tamamlar.

---

## 📁 Desteklenen Dosya Formatları

GameTranslator uygulamasında **Çeviri & Modeller** sekmesinden ya da **Özel Altyazı** sekmesinden `.json`, `.txt` veya `.srt` uzantılı yama dosyalarını doğrudan içe aktarabilirsiniz.

### 1. JSON Formatı (Önerilen)

#### Format A: Standart Detaylı JSON
```json
{
  "game": "Dead Island 2",
  "author": "Topluluk",
  "version": "1.0",
  "subtitles": {
    "No, she's gonna drown!": "Hayır, boğulacak!",
    "Where are you going?": "Nereye gidiyorsun?",
    "We need to find the keys.": "Anahtarları bulmamız gerek."
  }
}
```

#### Format B: Düz Sözlük JSON
```json
{
  "Hello": "Merhaba",
  "Follow me!": "Beni takip et!"
}
```

#### Format C: Dizi (Array) JSON
```json
[
  { "en": "Watch out!", "tr": "Dikkat et!" },
  { "en": "Grab the weapon.", "tr": "Silahı al." }
]
```

---

### 2. Metin (TXT / SRT) Formatı

Satır satır `İngilizce = Türkçe` veya sekme (tab) ile ayrılmış metinler:
```text
No, she's gonna drown! = Hayır, boğulacak!
Follow me = Beni takip et
Run! = Kaç!
```

---

## 🛠️ Yamaları Otomatik Dönüştürme Aracı (`patch_converter.py`)

Farklı yama sitelerinden (örneğin Psyama veya fan çeviri forumları) indirdiğiniz ham altyazı dökümlerini GameTranslator uyumlu JSON formatına tek komutla dönüştürebilirsiniz:

```bash
# Eşitlik (=) veya Tab ile ayrılmış TXT dosyasını JSON yamasına dönüştür:
python3 scripts/patch_converter.py --input raw_subtitles.txt --output patches/dead_island_2.json --game "Dead Island 2"

# İki ayrı İngilizce ve Türkçe satır listesini birleştir:
python3 scripts/patch_converter.py --en english_lines.txt --tr turkish_lines.txt --output patches/oyun_adi.json
```

---

## 🤝 Topluluğa Katkıda Bulunma

Kendi oyununuz için hazırladığınız veya dönüştürdüğünüz yama dosyalarını bu depoya ekleyip diğer oyuncularla paylaşabilirsiniz:

1. Bu depoyu GitHub'da **Fork** edin.
2. Hazırladığınız JSON dosyasını `patches/<oyun-adi>.json` olarak ekleyin.
3. Bir **Pull Request (PR)** gönderin. İncelenip onaylandıktan sonra tüm GameTranslator kullanıcılarının kullanımına açılacaktır!
