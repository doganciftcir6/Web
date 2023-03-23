let url ="https://www.sadikturan.com";
let kursAdi = "Komple Web Geliştirme Kursu";
let sonuc;
//birinci kaç karakterden oluşur
sonuc = kursAdi.length;

//ikinci kaç kelimeden oluşur
sonuc = kursAdi.split(" ").length;

// üçüncü url https ile mi başlıyor
sonuc = url.startsWith("https");
if(sonuc){
    console.log("evet başlıyor")
}

// dördüncü kursadi içinde eğitimi kelimesi var mı
sonuc = kursAdi.indexOf("Eğitimi");

// besinci url ve kursadi değişkenlerini kullanrak aşağıdaki string bilgiyi oluşturun
kursAdi = kursAdi.toLowerCase();
kursAdi = kursAdi.replaceAll(" ","_");
kursAdi = kursAdi.replace("ş","s").replace("ı","i");
sonuc = `${url}/${kursAdi}`;






console.log(sonuc);