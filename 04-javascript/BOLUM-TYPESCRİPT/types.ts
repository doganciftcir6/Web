// basit bir değişken tanımı yapalım
// eğer let a = 5 gibi bir tanımlama yaparsak sonradan a nın içerisine string bir ifade atamayız hata verir ama bu şekilde bir değer atmadan tanımlama yaparsak daha sonradan istediğimiz türde veri ataması yapabiliyoruz çünkü a nın tipi any oluyor
let a;
a = 5;
a = 'a';
a = true;
// başka değişkenler değişken tanımlarken değişkenin türünü belirtebiliyoruz
let b: number = 5;
let c: string = 'a';
let d: boolean = true;
let e: any;

// number türünde bir dizi tanımlaması da yapabiliriz
let f: number[] = [1,2,3];
// dizi için veya <> dizinin tipini bunların arasına yazabiliriz
let h: Array<number> = [1,2,3];
// diznin tipini any olarak belirtirsek istediğimiz türde veri koyabiliyoruz içerisine
let g: any[] = [1,'a',true];
// veya dizi tanımlaması ypaarken ilk gelecek sonraki gelecek bir sonraki gelecek verinin türünü belirtebiliyoruz buna tuple deniyor
let j: [string,number,boolean] = ['a',5,false];

// bir ödeme tipini tanımlıyor olalım
const krediPayment = 0;
const havalePayment = 1;
const eftPayment = 2;
// bunu kullanmak yerine enum yapısını kullanabiliyoruz enum yapısı normal javasciprtte aslında bir fonksiyona karşılık geliyor
enum Payment {kredi = 0,havale = 1,kapidaodeme = 2,eft = 3};
// ve sonra ben enum içerisindeki değerlere ihtiyaç duyduğumda bu şekilde kullanarak bu bilgiyi direkt olarak alabilirim
let kredi = Payment.kredi; //0
let havale = Payment.havale; //1
let kapidaodeme = Payment.kapidaodeme; //2
let eft = Payment.eft; //3
