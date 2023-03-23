// string aslında bir charcakter topluluğudur


let ad = "Sadık";
let soyad = "Turan";
let yas = 39;
let sehir = "Kocaeli";

let mesaj = "Benim adım " + ad + ' ve soyadım ' + soyad + '. ' + sehir + "'de yaşıyorum." + 'Emekliliğe ' + (65 - yas) + ' yılım kaldı.'
console.log(mesaj);
// bunun daha kolay yolu var
// backtick aracılığıyla `
mesaj = `Benim adım ${ad} ve soyadım ${soyad}. ${sehir}'de yaşıyorum.Emekliliğe ${65 - yas} yılım kaldı.`;
console.log(mesaj);

// ternary oparetorü ? " " : " "  (İF ELSE KISAYOL)
// eğer true değer getiriliyorsa ilk tırnak kısmı olur false getiriliyorsa ikinci tırnak kısmı olur
let emeklilik = (65-yas > 0) ? "Emekliliğe " + (65-yas) + " yıl kaldı." : "Zaten emekli oldunuz";
mesaj = `Benim adım ${ad} ve soyadım ${soyad}. ${sehir}'de yaşıyorum.${emeklilik}`;
console.log(mesaj);
