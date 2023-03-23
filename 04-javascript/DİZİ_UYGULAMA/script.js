// DİZİ OLULTUR
let meyveler = ["Elma", "Armut", "Muz", "Çilek"];

// DİZİ KAÇ ELEMANLI
console.log(meyveler.length);

// DİZİNİN İLK VE SON ELEMANI
console.log(meyveler[0]);
console.log(meyveler[meyveler.length-1]);

// elma dizinin bir elemanı mıdır
console.log(meyveler.includes("Elma"));
// veya
console.log(meyveler.indexOf("Elma"));

// kiraz meyvesini listenin sonuna ekleyiniz.
meyveler[meyveler.length] = "Kiraz";
// veya
meyveler.push("Kiraz");

// Dizinin son 2 elemanını siliniz.
meyveler.pop();
meyveler.pop();
//veya
meyveler.splice(meyveler.length - 2, 2);

// aşağıdaki bilgileri dizi içinde saklayın ve her öğrencinin yaşını ve not ortalamasını hesaplayın
let ogr1 = ["Yiğit", "Bilgi", 2010, [70,60,80]];
let ogr2 = ["Ada", "Bilgi", 2012, [80,80,90]];
let ogr3 = ["Ahmet", "Turan", 2009, [60,60,70]];
let ogrenciler = [ogr1,ogr2,ogr3];

let yigitYas = new Date().getFullYear() - ogrenciler[0][2];
console.log(yigitYas);
let adaYas = new Date().getFullYear() - ogrenciler[1][2];
console.log(adaYas);
let ahmetYas = new Date().getFullYear() - ogrenciler[2][2];
console.log(ahmetYas);

let yigitNot = (ogrenciler[0][3][0] + ogrenciler[0][3][1] + ogrenciler[0][3][2]) / 3;
// virgülden sonra 1 basamak yazsın .tofixed sayesinde
console.log(yigitNot.toFixed(1));
let adaNot = (ogrenciler[1][3][0] + ogrenciler[1][3][1] + ogrenciler[1][3][2]) / 3;
console.log(adaNot);
let ahmetNot = (ogrenciler[2][3][0] + ogrenciler[2][3][1] + ogrenciler[2][3][2]) / 3;
console.log(ahmetNot);





console.log(cevap);