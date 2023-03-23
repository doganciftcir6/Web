// belli bir amaç için tekrar tekrar yapacağımız işlemleri bir fonksiyona yaptırabiliriz
// class tan türerilmiş bir nesne üzerinden bir fonksiyon çağırıyorsak buna metot diyorduk
// eğer fonksiyonu direkt herhangi bir classa bağlu olmadan tanımlıyorsakta buna fonksiyon diyoruz 
// fonksiyon isimleri küçük harfle başlar
// parantezler içerisine dışarıdan göndereceğimiz parametreleri tanımlıyoruz

function selamlama() {
    console.log("merhaba")
}
// parametre alamayan bir fonksiyon tanımlamış olduk
// tanımladıktan sonra çağırıp kullanalım
selamlama();
 

// parametre alan bir function
// bu metotu çağırırken mutlaka parametresini girmek zorundayız boş bırakamayız
function selamlama2 (msg){
    console.log(msg)
}
selamlama2("naber müdür");


// farklı fonksiyon
// console.log yerine return dediğimiz zaman ve fonksyoni çağırıp çalıştırdığımız zaman ekranda bir değer göremeyiz 
function yasHesapla(dogumYili){
    return new Date().getFullYear() - dogumYili;
}
// fonksiyonu çalıştırıp dönen değeri bir değişken içinde saklayalım
let yasAhmet = yasHesapla(1987);

// retrun yapan bir fonksiyon
function emekiligeKacYilKaldi(dogumYili, isim){
    let yas = yasHesapla(dogumYili);
    let kalan_sene = 65 - yas;
    if(kalan_sene > 0){
        console.log(`${isim}, emekli olmanıza ${kalan_sene} yıl kaldı.`)
    }else{
        console.log("zaten emekli ooldunuz.");
    }
}
emekiligeKacYilKaldi(1980, "Ali");