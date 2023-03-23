// dizi tanımlayalım
let ogrenciler = ["çınar","yiğit","ada"];

// dizi elemanlarını saymak 3 döndürür
sonuc = ogrenciler.length;
// bir dizi elemanını stringe çevirmek
sonuc = ogrenciler.toString();
// bir dizi elemanını stringe çevirmek alternatif her bir eleman arasına boşluk veya - ekler artık parametreye ne verirsek birleştirir ve string yapar .join
sonuc = ogrenciler.join("-");
// dizinin son elemanını silinir ve silinen eleman ekrana yazdırılır
sonuc = ogrenciler.pop();
// dizinin elemanını silmeye alternatif yöntem poptan farklı olarak son eleman değilde ilk eleman silinip ekrana yazdırırlır
sonuc = ogrenciler.shift();
//diziye eleman eklemek dizinin sonuna eleman eklenir
sonuc = ogrenciler.push("sena");
// diziye eleman ekelemek alternatif dizinin başına eleman eklemek
sonuc = ogrenciler.unshift("ahmet");

// yeni bir dizi tanımlayalım
let markalar1 = ["mazda", "toyota"];
let markalar2 = ["opel", "renault"];
let markalar3 = ["bmw"];
// 3 dizimiz var ve bu dizileri birleştirmek istiyoruz burada orjinal dizi etkilenmez
sonuc = markalar1.concat(markalar2, markalar3);
// alternatif olarak .splice ile kimi zaman eleman eklemek veya eleman silmek için kullanılabilir
// oıncı indeksten başla sonra kaç eleman sil silmek istemiyorsak 0 deriz daha sonra ekleyecek olduğumuz dizi elemanlarını yazarız
sonuc = markalar1.splice(0, 0, markalar2);






console.log(sonuc);