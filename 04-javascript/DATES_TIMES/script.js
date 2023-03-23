// tarih nesnesi oluşturalım bu nesneyede simdi ismini verelim
let simdi = new Date(); //şimdiki tarih - saat bilgisi var

//GET METOTLARI şuanki tarih
sonuc = simdi;
// bütün tarih ve saat bilgisini almak yerine sadece gün bilgisini alabiliriz
sonuc = simdi.getDate();
// .getDay bize hangi gün olduğunu söyler 0 pazardan başlar 6 ya gadar gider 6 cumartesidir
sonuc = simdi.getDay();
// .getFullYear sadece yıl bilgisini verir
sonuc = simdi.getFullYear();
// .getHours sayesinde geriye saat biglsini verir
sonuc = simdi.getHours();
// .getMiliSeconds milisaniye bilgisini verir
sonuc = simdi.getMilliseconds();
// .getTime geriye saat bilgisini bize milisaniye türünden veriyor
sonuc = simdi.getTime();

// SET METOTLARI bunlar tarih nesnesi oluştuturken istediğimiz bir tarihe gideriz tarihi değiştirme güncelleme metotları
// .setFullYear ile yıl bilgisini değiştririz
simdi.setFullYear(2025);
// .setMonth ay bilgisini değiştirir
simdi.setMonth(7); //0:ocak
// .setDate gün bilgisini değiştirir
simdi.setDate(15);


// bir nesne oluşturalım
// konstraktır yani parametre için yıl ay ve gün bilgisini girelim
let dogumTarihi = new Date(1990, 5, 15);
// simdiki tarihten doğum yılını çıkartıp yaşı bulabiliriz
sonuc = simdi.getFullYear() - dogumTarihi.getFullYear();


let milisecond = simdi - dogumTarihi;
// bu değeri saniye cinsinden hesaplamış olalım
let saniye = milisecond / 1000;
// bu değeri dakika cinsinden hesaplamış olalım
let dakika = saniye / 60;
// bu değeri saat cinsinden hesaplamış olalım
let saat = dakika / 60;
// bu değeri gün cinsinden hesaplamış olalım
let gün = saat / 24;
sonuc = saniye;





console.log(sonuc);
console.log(typeof sonuc);
