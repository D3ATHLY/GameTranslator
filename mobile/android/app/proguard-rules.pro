# libgtnative.so (gt_jni.c) bu sınıfı ve geri çağrı yöntemlerini adlarıyla bulur; küçültme adlarını değiştirmemeli.
-keep class com.gametranslator.gametranslator_mobile.Native { *; }
-keep interface com.gametranslator.gametranslator_mobile.Native$* { *; }
-keepclassmembers class * implements com.gametranslator.gametranslator_mobile.Native$ConsoleCallback { public *; }
-keepclassmembers class * implements com.gametranslator.gametranslator_mobile.Native$LogCallback { public *; }
-keepclassmembers class * implements com.gametranslator.gametranslator_mobile.Native$SessionListener { public *; }

# ML Kit bileşenlerini yansımayla (ComponentRegistrar, parametresiz kurucu) bulur; küçültme kurucuları siliyordu
# ("NoSuchMethodException: ...VisionCommonRegistrar.<init>") ve yayın derlemesinde yazı tanıma hiç başlamıyordu.
-keep class com.google.mlkit.** { *; }
-keep class * implements com.google.firebase.components.ComponentRegistrar { *; }
-keep class com.google.android.gms.internal.mlkit_vision_text_common.** { *; }
-keep class com.google.android.gms.internal.mlkit_vision_text_bundled_common.** { *; }
-keep class com.google.android.gms.internal.mlkit_translate.** { *; }
-keep class com.google.android.gms.internal.mlkit_language_id_common.** { *; }
-keep class com.google.android.gms.internal.mlkit_common.** { *; }
-keep class com.google.android.gms.internal.mlkit_vision_common.** { *; }
