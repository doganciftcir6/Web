// dict, json benziyor sözlüklere benziyor yani
// obje içinde obje tanımlayabiliyoruz adres kısmındaki gibi
// obje içinde dizi tanımlayabiliyoruz hobiler kısmındaki gibi
let userA = {
    "ad" : "Sadık",
    "soyad" : "Turan",
    "yas" : 38,
    "adres" : {"sehir" : "kocaeli",
               "ilce" : "izmit"},
    "hobiler" : ["sinema", "spor"]            
}
// bir obje daha yani user daha oluşturalım
let userB = {
    "ad" : "Çınar",
    "soyad" : "Turan",
    "yas" : 5,
    "adres" : {"sehir" : "kocaeli",
               "ilce" : "izmit"},
    "hobiler" : ["sinema", "spor"]            
}

// obje elemanlarına ulaşmak
let sonuc;
// .ad dediğimizde artık sadık bilgisi gelir
sonuc = userA.ad;
// .soyad dediğimizde turan gelir
sonuc = userA.soyad;
// bu şekildede ulaşabiliirz yine yaş bilgisi gelir 38
sonuc = userA["yas"];
// obje içindeki objedeki elemanlara ulaşmak
sonuc = userA.adres.sehir;
sonuc = userA.adres.ilce;
// obje içindeki dizinin elemanlarına ulaşmak
sonuc = userA.hobiler[0];
sonuc = userA.hobiler[1];

// bir kullanicilar listesi yapalım artık kullaniciların 0ınci indeksi bize userA yı getirir
let kullanicilar = [userA, userB];
// yani burada userB nin ad bilgisi gelecektir
sonuc = kullanicilar[1].ad;

// dizi içerisinde direkt obje tanımlamaları yapabiliriz
let urunler = [
    {"urun_adi" : "samsung s22",
                 "urun_fiyat" : 13000 },
     {"urun_adi" : "samsung s23",
                 "urun_fiyat" : 15000 }
                ]
//bu elemanlara ulaşalım 0. indeks yani ilk objemizdeki ürün adı gelecektir samsung s22 
sonuc = urunler[0].urun_adi
console.log(sonuc);