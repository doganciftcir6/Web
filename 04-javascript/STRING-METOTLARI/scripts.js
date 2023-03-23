let kursAdi = "Komple Uygulamalı Web Geliştirme Eğitimi";

let sonuc;

// kursAdi. dediğimizde metotlara ulaşıyoruz
// toLowerCase metotu tüm karakterleri küçük harfe çevirir ve geriye string değer döndürür o yüzden o dönen değeri sonuc içerisine atabiliriz
sonuc = kursAdi.toLowerCase();
// toUpperCase metotu tüm karakterleri büyük harfe çevirir ve geriye string değer döndürür o yüzden o dönen değeri sonuc içerisine atabiliriz
sonuc = kursAdi.toUpperCase();
//.length string içerisindeki karakterleri sayar ve geriye bir number değer döndürür toplam karakter sayısını söyler bir propertiestir metot değildir
sonuc = kursAdi.length;
// 0. indeksteki elemanı göster anlamına gelir k gözükecektir
sonuc = kursAdi[0]
// slice metotu içerisine indeks numarası veririz 0ıncı indeksten başla  5. indekse kadar git fakat 5 dahil değil yani kompl dönecektir sağdan sola gider
sonuc = kursAdi.slice(0, 5);
// bir aralık belirtmezsek 10. indeksten itibaren başlar ve sona kadar gider hespini gösterir sağdan sola gider
sonuc = kursAdi.slice(10);
// eğer negatif bir değer belirtirsek bu sefer başlangıç indeksini sondan geriye saymaya başlar baştan 5. indekse kadar alır soldan sağa gider
sonuc = kursAdi.slice(-10, 5);
// eğer aralık  belirtmeden negatif değer verirsek bu sefer sondan geriye doğru 10. indeksten itibaren alıp baştan tüm stringi gösterir soldan sağa gider
sonuc = kursAdi.slice(-10);
// .substring metotu stringin 0. ile 6. indeksi arasında alır Komple gelir soldan sağa yani slice ile aynı işi yapıyor
sonuc = kursAdi.substring(0, 6);
// .substring metotu aralık belirtmezsek soldan sağa 10. indeksten itibaren tüm stringi alır gösterir slice ile aynı işi yapıyor
sonuc = kursAdi.slice(10);
// .replace metotu değiştirme yapar burada Eğitimi bilgisini bul ve onun yerine Kursu yaz demiş oluruz
sonuc = kursAdi.replace("Eğitimi","Kursu")
// .trim metotu stringteki başta sondaki tüm boşlukları siler
sonuc = kursAdi.trim();
// .trimEnd metotu ile sadece sondaki boşlukları sileriz
sonuc = kursAdi.trimEnd();
// .trimStart metotu ile sadece baştaki boşlukları sileriz
sonuc = kursAdi.trimStart();
// .indexOf metotu parantez içine verilen string elemanının başlangıç indexini geri döndürür arama yapar
sonuc = kursAdi.indexOf("Komple");
// .split metotu vermiş olduğunuz karakterle size bir string dizisi göndeirir
sonuc = kursAdi.split(" ");
// 0ıcı indekstekini al diyebiliyoruz komple gelcektir
sonuc = kursAdi.split(" ")[0];
// 3. indekstekini al diyoruz geliştirme gelecektir bir dizi oluşturup dizinin elemanlarına bu şekilde ulaşabiliriz
sonuc = kursAdi.split(" ")[3];
console.log(sonuc);