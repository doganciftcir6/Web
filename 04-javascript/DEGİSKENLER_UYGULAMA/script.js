
let ogrenci1Ad = "Ada"
let ogrenci1Soyad = "Bilgi"

let ogrenci2Ad = "Yiğit"
let ogrenci2Soyad = "Bilgi"

let ogrenci1DogumTarihi = "2010";
let ogrenci2DogumTarihi = "2012";

let ogrenci1MatematikNotu1 = 70;
let ogrenci1MatematikNotu2 = 70;
let ogrenci1MatematikNotu3 = 80;

let ogrenci2MatematikNotu1 = 40;
let ogrenci2MatematikNotu2 = 40;
let ogrenci2MatematikNotu3 = 50;


// şuanki yıl bilgisini alalım sadece yıl bilgisini alalım
let suankiYilBilgisi = new Date().getFullYear();

// parseInt ile string ifadeleri int a dönüştürelim
var ogrenci1Yas = suankiYilBilgisi - parseInt(ogrenci1DogumTarihi);
var ogrenci2Yas = suankiYilBilgisi - parseInt(ogrenci2DogumTarihi);
console.log("Ogrenci 1'in yaşı: " + ogrenci1Yas);
console.log("Ogrenci 2'in yaşı: " + ogrenci2Yas);


var ogrenci1Ortalama = (ogrenci1MatematikNotu1 + ogrenci1MatematikNotu2 + ogrenci1MatematikNotu3) / 3;
// bu bize ondalıklı bir değer döndürcektir ama ben tam sayı ile ilgileniyorum ondan parseInt ile çevirme yapıcam
console.log("Ogrenci 1'in not ortalaması: " + parseInt(ogrenci1Ortalama));
var ogrenci2Ortalama = (ogrenci2MatematikNotu1 + ogrenci2MatematikNotu2 + ogrenci2MatematikNotu3) / 3;
console.log("Ogrenci 2'in not ortalaması: " + parseInt(ogrenci2Ortalama));


var ogrenc1Gectimi = (ogrenci1Ortalama >= 50)
console.log("Ogrenci 1 dersten geçmiştir" + ogrenc1Gectimi)
var ogrenc2Gectimi = (ogrenci2Ortalama >= 50)
console.log("Ogrenci 2 dersten geçememiştir" + ogrenc2Gectimi)
