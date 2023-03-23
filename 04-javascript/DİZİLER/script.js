let urun17 = "iphone 12";
let urun28 = "iphone 13";
let urun39 = "iphone 14";
// bu kullanım saçma olur bunun yerine dizi tanımlarız
// dzi tanımlama
let urunler = ["iphone 12" , "iphone 13", "iphone 14"];
let fiyatlar = [9000, 12000, 20000];
let renkler = ["gold", "siyah", "beyaz"];
// bu elemanlara ulaşmak için
console.log(urunler[0]);
console.log(urunler[1]);
console.log(urunler[2]);
// veya bütün ürün bilgilerini bu şekilde ekrana yazdırabiliyoruz
console.log(`${urunler[0]}-${fiyatlar[0]}-${renkler[0]}`)
console.log(`${urunler[1]}-${fiyatlar[1]}-${renkler[1]}`)
console.log(`${urunler[2]}-${fiyatlar[2]}-${renkler[2]}`)
// eğer çok fazla eleman varsa o elemanlara ulaşmak için döngü kullanılır

// yeni dizi yani aynı dizi içinde farklı değişken veri türleri tanımlanabirlir
let urun1 = ["iphone 12", 9000, "gold"];
let urun2 = ["iphone 13", 12000, "siyah"];
let urun3 = ["iphone 14", 20000, "beyaz"];
// dizilerin indekslerine yeni eleman atama değiştirme yani
// urun 2 nin 0 ıncı indeksine iphone15 atadık
urun2[0] = "iphone 15";
// böyle bir kullanımda var dizi içinde dizi tanımlayabiliriz mesela birden fazla rengi var diyelim telefonun
let urun4 = ["iphone 16", 30000, ["siyah", "beyaz", "kırmızı"]];
// bu dizi içindeki dizi elemanına ulaşmak için ikinci indeskteler yani 
console.log(urun4[2]);
// bu dizi içindeki dizinin alt elemanlarına ulaşmak için yani ikinc indeksteki dizi elamanının 0. indeksteki elemanı demiş oluruz
console.log([2][0]);

// bunlar artabilir mesela:
let urun5 = ["iphone 16", 30000, ["purple", "orange", "green", ["64gb,32gb,16gb"]]];
//dizi içindeki dizinin içindeki dizi elemanına ulaşmak
console.log([2][0][0]);




// aslında buradaki stringeki her bir karakter bir dizinin elemanıdır
let kursAdi = "Komple web Geliştirme Eğitimi";
console.log(kursAdi[5]);
// string bir yapıyı diziye dönüştürmek ve 3. indeksteki elemana ulaşmak
console.log(kursAdi.split(" ")[3]);
