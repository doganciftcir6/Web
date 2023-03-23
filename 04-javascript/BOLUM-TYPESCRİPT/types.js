// basit bir değişken tanımı yapalım
// eğer let a = 5 gibi bir tanımlama yaparsak sonradan a nın içerisine string bir ifade atamayız hata verir ama bu şekilde bir değer atmadan tanımlama yaparsak daha sonradan istediğimiz türde veri ataması yapabiliyoruz çünkü a nın tipi any oluyor
var a;
a = 5;
a = 'a';
a = true;
// başka değişkenler değişken tanımlarken değişkenin türünü belirtebiliyoruz
var b = 5;
var c = 'a';
var d = true;
var e;
// number türünde bir dizi tanımlaması da yapabiliriz
var f = [1, 2, 3];
// dizi için veya <> dizinin tipini bunların arasına yazabiliriz
var h = [1, 2, 3];
// diznin tipini any olarak belirtirsek istediğimiz türde veri koyabiliyoruz içerisine
var g = [1, 'a', true];
// veya dizi tanımlaması ypaarken ilk gelecek sonraki gelecek bir sonraki gelecek verinin türünü belirtebiliyoruz buna tuple deniyor
var j = ['a', 5, false];
// bir ödeme tipini tanımlıyor olalım
var krediPayment = 0;
var havalePayment = 1;
var eftPayment = 2;
// bunu kullanmak yerine enum yapısını kullanabiliyoruz
var Payment;
(function (Payment) {
    Payment[Payment["kredi"] = 0] = "kredi";
    Payment[Payment["havale"] = 1] = "havale";
    Payment[Payment["kapidaodeme"] = 2] = "kapidaodeme";
    Payment[Payment["eft"] = 3] = "eft";
})(Payment || (Payment = {}));
;
// ve sonra ben enum içerisindeki değerlere ihtiyaç duyduğumda bu şekilde kullanarak bu bilgiyi direkt olarak alabilirim
var kredi = Payment.kredi; //0
var havale = Payment.havale; //1
var kapidaodeme = Payment.kapidaodeme; //2
var eft = Payment.eft; //3
