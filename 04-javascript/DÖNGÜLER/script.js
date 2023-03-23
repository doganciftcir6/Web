// önce değişkeni tanımlarız for içine
// sonra koşulu yazıyoruz aslında burada true değer üretiyor burası false olduğunda döngü sona erer
// sonda i yi bir arttırmazsak i her seferinde 0 olur ve sonsuz bir döngüye gireriz
// 0 dan 9 a kadar ekrana yazılır burada
for(let i = 0 ; i < 10; i++){
    console.log(i);
}

// 1 den 10 a kadar olan sayıların toplamı
let toplam = 0;
for(let i = 1; i <= 10; i++){
    toplam+=i;
}
console.log(toplam);

// bir dizimiz olsun ve dizideki tüm elemanların toplamını alalım
let sayilar = [1,4,5,8,4,3];
// normalde böyle yapardık ama bu çok uzun bir işlem olur döngü kullanmak gerek
console.log(sayilar[0] + sayilar[1] + sayilar[2] + sayilar[3] + sayilar[4] + sayilar[5]);
// döngüyü yapalım
let toplam2 = 0;
for(let i = 0 ; i < sayilar.length; i++){
    toplam += sayilar[i];
}
console.log(toplam);
// yada farklı bir for kullanımı yapabiliriz
// sayilar değişkeninin içinden verilerin indeks numaraları kadar al yani 0 dan başlar kaç tane indeks varsa o kadar alır index değişkenine at deriz dolayısıyıla 10 indeks varsa 0 dan 10 a kadar sayar
// biz burda yine toplam alalım
for( let index in sayilar){
    // console.log(index);
    toplam += sayilar[index];
}

// ya da indekslerle uğraşmak istemiyorsak
// sayilar değişkeninin içindeki elemanların bu sefer indeks numaralarını değil kendi değerlerlerini alır
for(let sayi of sayilar){
//    console.log(sayi);
toplam += sayi;
}

// obje üzerinde for döngüsü
let user = {
    "name" : "Sadık Turan",
    "username" : "sadikturan",
    "password" : "12345",
    "email" : "info@sadikturan.com"
};

for(let key in user){
    // keylere ulaşmak
    console.log(key);
    // valuelere ulaşmak
    console.log(user[key]);
}