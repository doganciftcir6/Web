//değişken tanımlarken var yerine let kullanabiliri aralarında fark var ancak şuanlık bununla ilgilenmicez.


var urunAdi = "iphone 13";  //string
let urunFiyat = 15000;    //number

// typeof bize değişkenin türünü söyleyecektir geri döndürecektir
console.log(typeof urunAdi);
console.log(typeof urunFiyat);

// iki değişken tanımlayalım string türünde
let sayi1 = "10";
let sayi2 = "20";
// ve bir toplama işlemi yapalım fakat burada toplama yaptığımızda bunlar string ifade olduğu için 10 ve 20 yi yan yana yazar toplama yapmasını istiyorsak "" işaretini kaldırmalı ve değişkenlerimizi number türünde tanımlamış olmalıyız veya bir tür dönüşüm işlemi yapılabilir değişkenlerin başına number ekleyerek değişkenleri numbera çevririz ancak çevrilebiliyor olması gerekli burası önemli
console.log(Number(sayi1) + Number(sayi2));
 
// iki değişken tanımlayalım nunber türünde
let sayi3 = 10;
let sayi4 = 20;
// biz bunları sayısal şekikde değilde string şekilde toplamak istiyoruz yani değerler yan yana yazılsın toplanmasın o yüzden string dönüştürme işlemi yapıcaz .toString ile
console.log(sayi3.toString() + sayi4.toString());


//bir değişken tanımlayalım
let sinavNotu = 70;
// eğer sınavnotu 50 den büyük veya eşitse true değerini döndürecektir eğer bu şarta uymuyorsa false döndürecektir
let basarilimi = (sinavNotu >= 50) //boolen değişken türü bu oluyor

// son olarak bir değiken türü daha var
// bir değer atamayalım sadece değişken tanımlayalım bu durumda değiken tipi undefined olur
let yas;  //undefined
