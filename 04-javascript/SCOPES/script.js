var isim = "Ahmet"; //global scope
// CONST İLE SABİT BİR DEĞİŞKEN TANIMLARIZ UYGULUMA BOYUNCA DEĞİŞTİRİLMEMESİNİ İSTEDİĞİMİZ DEĞİŞKENLERİ CONST İLE TANIMLARIZ CONST DEĞİŞKENLER SONRADAN DEĞİŞTİRİLMEZ HATA VERİR
const constdegisken = 234;

function yazdir(){
    var isim = "Ayşe"; //ayrı kapsam scope blockscope
    var yas = 20;      //ayrı kapsam scope blockscope
    console.log("funciton scope: ",isim , yas);
}
if(true){
    var ifisim = "Zeynep"; //global scope
    console.log(ifisim);
}
// if bloğu içindeki isim değişkenine burada ulaşabiliriz bunu fonksiyonda yaptığımızda ulaşamıyorduk
console.log(ifisim);

if(true){
    let ifisim2 = "Zeynep"; //ayrı kapsam scope blockscope
    console.log(ifisim2);
}
// if bloğu içindeki isim değişkenine burada ulaşamayız çünkü LET ile tanımlama yaptık aynı fonksiyondaki gibi global olmadı
console.log(ifisim2);


yazdir();
// buradaki ulaştığımız isim fonksiyonun üstünde global tanımladığımız isim değişkeni yoksa fonksiyon içindeki değişkene ulaşamayaız
console.log(isim);
// fonksiyonun içinde tanımlanan yaş değişkinine burada ulaşamayız 


// fonksiyonlar kendi scope alanlarını oluşturur
// block içerisinde yeni bir scope oluşur (let,const) ancak (var) ile oluşturduğumuz değişken global bir tanımlama yapıyor ve block scope oluşmaz global scope oluşur
// CONST İLE SABİT BİR DEĞİŞKEN TANIMLARIZ UYGULUMA BOYUNCA DEĞİŞTİRİLMEMESİNİ İSTEDİĞİMİZ DEĞİŞKENLERİ CONST İLE TANIMLARIZ CONST DEĞİŞKENLER SONRADAN DEĞİŞTİRİLMEZ HATA VERİR