// girilen mesajı istediğin kadar kere ekrana yazdıran fonksiyon
function kelimeYazdir(kelime, adet) {
    for(let i = 0; i < adet ;i++){
        console.log(kelime);
    }
}
kelimeYazdir("ali",10);

// dikdörtgenin çevresini ve alanını hesaplayan fonksiyon
function alanCevreHesapla(kisa, uzun){
    let alan = kisa * uzun;
    let cevre = (kisa + uzun) * 2;
    return `alan: ${alan} çevre: ${cevre}`;
}
let sonuc = alanCevreHesapla(7, 10);
console.log(sonuc);
// yazı tura uygulaması fonksion
function yaziTuraAt(){
    let random = Math.random();
    if(random > 0.5){
        return `yazı geldi ve sayınızda ${random}`
    }else{
        return `tura geldi ve sayınızda ${random}`
    }
}
let sans = yaziTuraAt();
console.log(sans);
// kendisine gönderilen bir sayının tam bölümlerini dizi şeklinde döndüren foksiyon
function tamBolenler(sayi){
    let sayilar = [];
    for(let i=2; i < sayi; i++){
        if(sayi % i == 0){
            sayilar.push(i);
        }
    }


    return sayilar;

}
console.log(tamBolenler(10));
// değişen sayıda parametre alan toplama işlemi yapan bir fonksiyon
function toplam(){
    let sonuc = 0;

    for(let i = 0; i < arguments.length; i++){
        sonuc += arguments[i];
    }
    return sonuc;
}
console.log(toplam(2,4));
console.log(toplam(2,4,7,8,4,3,6));
console.log(toplam(2));