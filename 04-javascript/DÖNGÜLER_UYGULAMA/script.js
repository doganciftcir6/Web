let sayilar = [1,5,7,15,3,25,2,4];
// her bir elemanın karesi
for(let i = 0; i < sayilar.length; i++){
    karesi = Math.pow(sayilar[i] , 2);
    console.log(karesi);
}
// hangi sayılar 5 in katı
for(let i = 0; i < sayilar.length; i++){
    if(sayilar[i] % 5 == 0){
        console.log(sayilar[i]);
    }
}
console.log("karışma");

// çift sayıların toplamı
let toplam = 0; 
for(let i = 0; i < sayilar.length; i++){
    if(sayilar[i] % 2 == 0){
        toplam += sayilar[i];
    }
}
console.log(toplam);

// tüm karakterleri büyük harfle yazdırın
let urunler = ["iphone 12", "samsung s22", "iphone 13", "samsung s23"];
// tüm karakterleri büyük harfle yazdırın
for(let i of urunler){
    console.log(i.toUpperCase());
}

// listede samsung geçen kaç ürün var
let adet = 0;
for(let i of urunler){
    if(i.includes("samsung")) {
        adet++;
    }
}
console.log(adet);

// obje
let ogrenciler = [
    {"ad" : "yigit", "soyad" : "bilgi", "notlar" : [60,70,60]},
    {"ad" : "ada", "soyad" : "bilgi", "notlar" : [80,70,80]},
    {"ad" : "çınar", "soyad" : "turan", "notlar": [10,20,60]}
];

// her öğrencinin not orlaması ve başarı durumları
for(let ogrenci of ogrenciler){
    let notToplam = 0;
    let notOrtalama = 0;
    let adet = 0;
    for(let not of ogrenci.notlar){
        notToplam += not;
        adet++
    }
    notOrtalama = notToplam  / adet;
    console.log(`${ogrenci.ad} ${ogrenci.soyad} isimli öğrencinin not ortalaması : ${notOrtalama}. `);
    if(notOrtalama >= 50 && notOrtalama < 70){
        console.log("başarılı.")
    }else if(notOrtalama >= 70 && notOrtalama < 85){
        console.log("çok başarılı.")
    }else if(notOrtalama >= 85){
        console.log("süpper başarılı.")
    }else{
        console.log("başarısız.")
    }
}