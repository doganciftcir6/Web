let sonuc;
// tip dönüşümleri
sonuc= Number("10");
sonuc = parseInt("10.6");
sonuc = parseFloat("10.6");
sonuc = parseInt("10a");

// sayısal bir değer değil mi şeklinde bir soru soruyoruz burada evet der a olduğu için ama düz 10 yazarsak false der yani bu bir sayısal değerdir anlamına gelir
sonuc = isNaN("10a");

let sayi = 15.42342432;
// .toprecision metotu parantez içine girilen sayı kadar soldan itibaren ver burada 5 basamak kadar geri döndürecek baştan itibaren
// bütün sayı üzerinden geriye 5 basamk kadar değer döndürür
// sonda verilen değer değişir eğer sondaki sayı 0 a daha yakınsa bir alt değer gelir 10 a daha yakınsa üst değer gelir
sonuc = sayi.toPrecision(5);
// buda ondalıklı sayıdan itibaren almaya başlıyor 5 parameteesi yolladık . dan sonra soldan sağa şekilde 5 basamak verecek ondalıklı kısım her zaman 5 basamaklı olur
// aynı yuvarlama olayı var
sonuc = sayi.toFixed(5);
// yuvarlama yapar 2.4 2 ye yakın olduğu için 2 ye yuvarlar
sonuc = Math.round(2.4);
//.ceil her zaman yukarıya yuvarlar aşağı yuvarlama yapmaz 3 e yuvarlar
sonuc = Math.ceil(2.4);
// .floor her zaman alta yuvarlar yukarı yuvarlama yapmaz 2 ye yuvarlar
sonuc = Math.floor(2.4);
//.sqrt karekökü alır 5 gelir
sonuc = Math.sqrt(25);
// .pow üs alır 2 üssü 3 olur ilk parametre taban sayı ikincisi üs sayısı
sonuc = Math.pow(2,3);
//.abs mutlak değer alır
sonuc = Math.abs(-10);
// .min metotu parametre içindeki sayıların en küçüğünü  geri döndürür
sonuc = Math.min(2,4,5,3,6,7,2);
// .max metotu parametre içindeki sayıların en büyüğünü  geri döndürür
sonuc = Math.max(2,4,5,3,6,7,2);
// .random metotu rastegele bir sayı üretir bu sayı 0 ile 1 arasındadır
sonuc = Math.random();
// .random metotunu 0 ile 9 arasında rastgele sayı üretmek
sonuc = Math.random() * 10;
// .rando mmetotu ile 1 ile 10 arasında rastgele sayı üretmek bu 1 yerine 50 5 eklersek 5 ile 10 arasında olur
sonuc = (Math.random() * 10) + 1;








console.log(typeof sonuc);
console.log(sonuc);