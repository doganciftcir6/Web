// soru ile alakalı olan bütün kodlar burada olsun

// bir fonkisyon tanımlayalım aslında burada bir kalıp tanımlıyoruz
// burada bunu bir konstraktır olarak kullnadığımızdan dolayı büyük harfle başlamalıyız
function Soru(soruMetni, cevapSecenekleri, dogruCevap){
    // this ile bu konstraktırdan yani Sorudan bir kopya oluştururken o kopyanın soruMetni alanına dışarıdan gönderecek olduğumuz soruMetnini aktarıyoruz yani
    this.soruMetni = soruMetni;
    this.cevapSecenekleri = cevapSecenekleri;
    this.dogruCevap = dogruCevap;
    // buraya metotta ekleyebiliyoruz
    // this.cevabiKontrolEt = function(cevap){
    //     return cevap == this.dogruCevap
    // }
}
// konstraktır metotunu bu şekilde dışarıda da tanımlayabiliyoruz
// bu sayede örneğin 200 tane soru tanımlamış olsak 200 kere bu fonksiyonu tekrarlamış olmuyoruz 
// bir konstraktır içinde birden çok fonksiyon olabilir o yüzden bunu konstraktır içine tanımak yerine prototype altında toplayarak daha perdormanslı bir uygulama yapmış oluyorun
 Soru.prototype.cevabiKontrolEt = function(cevap){
        return cevap == this.dogruCevap
    }

// her bir soru soru diye tanımlanabilir
// let soru = {
//     soruMetni: "hangisi javascript paket yönetim uygulamasıdır ?",
//     cevapSecenekleri: {
//         a: "Node.js",
//         b: "Typescript",
//         c: "Npm"
//     },
//     dogruCevap : "c",
//     // obje içerisinde bir tane fonksiyon tanımlıcam
//     // fonkstion dışarıdan bir cevap bilgisi alsın
//     // this ile sorunun içerisindeki dogruCevap değişkeni ile dışarıdan gönderdiğimiz cevap değişkeni eşit mi
//     // bu fonksiyon buradaki objeye hizmet ediyor önemli olan bu
//     cevabiKontrolEt: function(cevap){
//         return cevap == this.dogruCevap
//     }
// }
// bir soru daha
// let soru2 = {
//     soruMetni: "hangisi .net paket yönetim uygulamasıdır ?",
//     cevapSecenekleri: {
//         a: "Node.js",
//         b: "Nuget",
//         c: "Npm"
//     },
//     dogruCevap : "b",
//     // obje içerisinde bir tane fonksiyon tanımlıcam
//     // fonkstion dışarıdan bir cevap bilgisi alsın
//     // this ile sorunun içerisindeki dogruCevap değişkeni ile dışarıdan gönderdiğimiz cevap değişkeni eşit mi
//     // bu fonksiyon buradaki objeye hizmet ediyor önemli olan bu
//     cevabiKontrolEt: function(cevap){
//         return cevap == this.dogruCevap
//     }
// }







// artık Soru dan bir nesne üreticez
// soru 1 isminde bir nesne üretiyorum küçük harfle
// soru konstraktırından bir tane kopya üreticem diyorum new diyerek
// kopyaya soru1 ismini verdik
// let soru1 = new Soru("hangisi javascript paket yönetim uygulamasıdır ?",{a: "Node.js", b: "Typescript", c: "Npm"},"c");
// // artık soru 2 yi üretmek istediğimde yapmam gereken
// let soru2 = new Soru("hangisi .NET paket yönetim uygulamasıdır ?",{a: "Node.js", b: "Nuget", c: "Npm"},"b");

// // artık soru 1 nesnesi üzerinden . diyerek bu parametrelere erişebiliyorum
// console.log(soru1.soruMetni);
// console.log(soru1.dogruCevap);
// console.log(soru1.cevabiKontrolEt("c"));
// // soru 1 nesnesi üzerinden erişelim
// console.log(soru2.soruMetni);
// console.log(soru2.dogruCevap);

// hatta nesne oluştururken her birine isim vermek zorunda da değiliz bir dizi tanımlayarak dizi içinde yeni nesneler oluşturabiliriz
let sorular = [
    new Soru("1-hangisi javascript paket yönetim uygulamasıdır ?",{a: "Node.js", b: "Typescript", c: "Npm", d: "Nuget"},"c"),
    new Soru("2-hangisi javascript paket yönetim uygulamasıdır ?",{a: "Node.js", b: "Typescript", c: "Npm", d: "Nuget"},"c"),
    new Soru("3-hangisi javascript paket yönetim uygulamasıdır ?",{a: "Node.js", b: "Typescript", c: "Npm", d: "Nuget"},"c"),
    new Soru("4-hangisi javascript paket yönetim uygulamasıdır ?",{a: "Node.js", b: "Typescript", c: "Npm", d: "Nuget"},"c"),
];
// dizinin bilgilerine ulaşmak
// console.log(sorular[0].soruMetni);
// // bir döngü ile tüm dizi elemanlarını gezebiliriz
// for(let s of sorular){
//     console.log(s.soruMetni);
// }
// dışarıda tanımladığımız fkonksiyonu kullanalaım
// console.log(soru1.cevabiKontrolEt("c"));    