// OOP : NESNE TABANLI PROGRAMLAMA
// OBJECT 
// TANIMLAMIŞ OLDUĞUMUZ OBJELERE HİZMET EDEN MOTOTLAR TANIMLAYABİLİYORUZ

// BİZ SÜREKLİ SORU OLUŞTURMAK İÇİN KODLAR YAZMAK YERİNE BİR SINIF TANIMLASAK VE O SINIFTAN HER OLUŞTURMUŞ OLDUĞUMUZ KOPYA ÜZERİNDEN DE O KOPYAYA BİR NESNE İSMİ VERMİŞ OLSA VE BEN QUİZ UYGULAMASI İÇERİSİNDE ÖRNEĞİN 30 TANE SORU OLUŞTURUCAKSAM BU DURUMDA NESNEDEN 30 KERE OLUŞTURDUĞUMDA BU KALIPTA TAMAMEN SINIFA BAĞLI OLDUĞUNDAN DOLAYI HER BİR NESNE AYNI ÖZELLİKLERE AYNI METOTLARA SAHİP OALCAĞINDAN İŞİMİZ KOLAYLAŞACAK

// SINIF, CONSTRUCTOR ==> NESNE * 30
// ES5 TARAFINDAN DESTEKLENİYOR ES6,ES7 VERSİYONLARI YAZSAK BİLE ES5 E ÇEVRİLİP GARANTİ ALTINA ALINMALI



// *******************************************************************************

// bir nesne üretelim bu konstraktırdan
const quiz = new Quiz(sorular);
// UI classını kullanalım
const ui = new UI();


// oluşturmuş olduğumuz quizi başlat butonuna quaryselector ile erişelim vermiş olduğumuz .btn-start classı aracılığıyla erişicez ve buna bir tane click event ekleyelim
// ve evente ekleyeceğimiz fonksiyonun yaptığı işte quizlerinden bize bir tane soru getirsin
ui.btn_start.addEventListener("click", function(){
    ui.quiz_box.classList.add("active");
    // süre kısmı için fonksiyonu çağıralım
    startTimer(10);
    // üre kısmı animasyonu için fonksiyonu çağıralım
    startTimerLine();
    ui.soruGoster(quiz.soruGetir());
    // soru sırası kısmı
    ui.soruSayisiniGoster(quiz.soruIndex + 1, quiz.sorular.length);
    // cevap verilince sonraki butonu ortaya çıksın
    ui.btn_next.classList.remove("show");
})
// sonraki soru butonuna baslıdğında sornaki soruya geçsin
ui.btn_next.addEventListener("click", function(){
     // tüm sorula geldikten sonra 5. soru olmadığı için undefind geliyor onun için koşul ekleyelim
     if(quiz.sorular.length != quiz.soruIndex + 1){
        // tamam soruları sıra sıra getirdi fakat sorular 4 ü geçince 5inci soru olmadığı için
        // ve burada index bilgisini bir arttılarım ki bir sonraki soru geslin hep aynı soru gelmesin
        quiz.soruIndex += 1;
        // süre kısmı için sonraki soruya geçildiğinde süreyi baştan başlatıcaz ama mevcut olan süreyide silmemiz gerekiyor
        clearInterval(counter);
         // süre kısmı animasyonu için sonraki soruya geçtiğimizde tekrar aynı fonksiyonu çağırıyor olmalıyız ancak önce mevcut bilgiyi sıfırlayalın
        clearInterval(counterLine);
        // süre kısmı için diğer soruya geçtiğimizde süre tekrar baştan başlayıp geriye sayması için
        startTimer(10);
        // süre kısmı animasyonu için sonraki soruya geçtiğimizde animasyon tekrar başlasın baştan
        startTimerLine();
        
        // soru bilgisini alıyoruz dolayısıyla artık listelyebiliriz
        ui.soruGoster(quiz.soruGetir());
        // soru sırası kısmı
    ui.soruSayisiniGoster(quiz.soruIndex + 1, quiz.sorular.length);
        // cevap verilince sonraki butonu ortaya çıksın
    ui.btn_next.classList.remove("show");
        
    }else{
        console.log("quiz bitti");
        // her quiz bittiğinde süre kısmını sıfırlamış olalım
        clearInterval(counter);
        // skor kısmı için quiz bittiği anda score kısmını göstericez
        ui.quiz_box.classList.remove("active");
        ui.score_box.classList.add("active");
        // tanımlamış olduğumuz fonksiyonu çağıralım skor kısmı için
        ui.skoruGoster(quiz.sorular.length, quiz.dogruCevapSayisi);
    }

});
// skor kısmındaki butonların çalışması için
ui.btn_quit.addEventListener("click", function(){
    // sayfayı yenilemiş olalım
    window.location.reload();
});
// replay butonunuda yapalım
ui.btn_replay.addEventListener("click", function(){
   quiz.soruIndex = 0;
   quiz.dogruCevapSayisi = 0;
//    burada replay butonuna tıklandığında mevcut değerleri sıfırladık ve js aracılığıyla start butonuna tekrar tıklamış olduk yani o kodlar tekrar çalıştırıalcak ve scoreboxtun active classını silerek scorboxu sayfadan kapatmış olalım
   ui.btn_start.click();
   ui.score_box.classList.remove("active");
});


function optionSelected(option){
    // ben bir şık işaretlediğim anda sayılan sürenin durması gerekiyor süre kısmı için
    clearInterval(counter);
    // süre kısmı animasyonu bir seçenek seçtiğimizde duruyor olmalı
    clearInterval(counterLine);
    let cevap = option.querySelector("span b").textContent;
    let soru = quiz.soruGetir();
    if(soru.cevabiKontrolEt(cevap)){
        // skor kısmı için doğru cevap değişkeni
        quiz.dogruCevapSayisi += 1;
        option.classList.add("correct");
        option.insertAdjacentHTML("beforeend", ui.correctIcon);
    }else{
        option.classList.add("incorrect");
        option.insertAdjacentHTML("beforeend", ui.incorrectIcon);
    }
    // sadece bir tane şık seçilsin
    for(let i=0; i< ui.option_list.children.length; i++){
        ui.option_list.children[i].classList.add("disabled");

    }
    // cevap verilince sonraki butonu ortaya çıksın
    ui.btn_next.classList.add("show");
}


// süre kısmı için setintervalı iptal etmek için bir değişken
let counter;
// süre kısmı için yeni fonksiyon
function startTimer(time){
    // setInterval time ismindeki fonksiyonu bulacak ve bu fonksiyonu 1 saniyede bir çalıştıracak sonsuza kadar
    counter = setInterval(timer, 1000);

    function timer(){
        ui.time_second.textContent = time;
        time--;
        if(time < 0){
            // time 0 ın altına indiyse setintervalı iptal etmem gerek
            clearInterval(counter);

            // kalan süre 0 olduğunda 0 yerine süre bitti yazdırabiliriz
            ui.time_text.textContent = "Süre Bitti";

            // süre bittikten sonra doğru cevabı otomatik olarak işaretleyelim
            let cevap = quiz.soruGetir().dogruCevap;
            // bütün optionları dolaşalım
            // bütün elemanlar children ile gelir
            for(let option of ui.option_list.children){
                if(option.querySelector("span b").textContent == cevap){
                    option.classList.add("correct");
                    option.insertAdjacentHTML("beforeend", ui.correctIcon);
                }
                //artık doğru cevap seçilmiş olur ancak kullanıcı seçim yapamamalı onuda yapalım
                option.classList.add("disabled");
            }
            // cevap işaretlendikten sonra sonraki soru botununda gösterilmesi gerekiyor
            ui.btn_next.classList.add("show");
        }
    }
}
// süre kısmı animasyonu için yeni fonksiyon
let counterLine;
function startTimerLine(){
    let line_width = 0;

    counterLine = setInterval(timer, 100);
    function timer(){
        line_width += 5;
        ui.time_line.style.width = line_width + "px";
        // bu çizginin genişlik bitinced durması gerekiyor o yüzden kontrol yapalım
        if(line_width > 549){
            clearInterval(counterLine)

        }
    }
}