// burada sürekli kullanacak olduğumuz class erişimlerini vs değişken olarak tanımlıcaz öyle kullancaz ana scriptte vs
function UI(){
    this.btn_start = document.querySelector(".btn_start"),
    this.btn_next = document.querySelector(".next_btn"),
    this.btn_replay = document.querySelector(".btn_replay"),
    this.btn_quit = document.querySelector(".btn_quit"),
    this.quiz_box = document.querySelector(".quiz_box"),
    this.score_box = document.querySelector(".score_box"),
    this.option_list = document.querySelector(".option_list"),
    this.correctIcon = '<div class="icon"><i class="fas fa-check"></i></div>',
    this.incorrectIcon = '<div class="icon"><i class="fas fa-times"></i></div>',
    this.time_text = document.querySelector(".time_text"),
    this.time_second = document.querySelector(".time_second"),
    this.time_line = document.querySelector(".time_line")
}
// daha sonra bir fonksyion oluşturalım bunun amacı dışarıdan almış olduğu soru objesine göre bir listeleme yapıcak
// bu fonksiyon sayesinde içine sorugetir fonksiyonunu vererek soru bilgisini vererek ekrana o soruyu yazdırıyoruz
UI.prototype.soruGoster = function(soru){
    // soru metni burada gösterilecek
    let question = `<span>${soru.soruMetni}</span>`;
    // soru bilgisini oluşturduk daha sonra
    // soru cevapları burada gösterilecek
    let options = ``;
    // bu başlangıçta boş olsun çünkü dinamik olacak bunun için bir döngü kullanıcaz
    // for döngüsüne tanımladığımız cevap aslında a b c bilgisi
    for(let cevap in soru.cevapSecenekleri){
        options +=
            `
            <div class ="option">
              <span><b>${cevap}</b>: ${soru.cevapSecenekleri[cevap]}</span>
            </div>
            `;
    }
    // TIKLADĞIMIZDA DOĞRU CEVAP YANLIŞ CEVAP DESİN CEVAP SEÇENEKLERİNİN KONTROLÜ KISMI
    document.querySelector(".question_text").innerHTML = question;
   this.option_list.innerHTML = options;

   //option listesi altındaki bütün elemanlara ulaşıcam
   const option = this.option_list.querySelectorAll(".option");

   for(let opt of option){
    // artık tüm optionlara tek tek ulaşmış oluruz dolayısıyla event ekleyebiliriz
    opt.setAttribute("onclick", "optionSelected(this)")
   }
}

// SORU SAYISININ GÖSTERİLMESİ KISMI
UI.prototype.soruSayisiniGoster = function(soruSirasi, toplamSoru){
    let tag = `<span class="badge bg-warning">${soruSirasi} / ${toplamSoru}</span>`;
    document.querySelector(".quiz_box .question_index").innerHTML = tag;
}

// SKOR BİLGİSİNDEKİ SAYILARI DİNAMİK HALE GETİRİCEZ
UI.prototype.skoruGoster = function(toplamSoru, dogruCevap){
    let tag = `Toplam ${toplamSoru} sorudan ${dogruCevap} doğru cevap verdiniz.`;
    // bu içeriği nereye eklicez
    document.querySelector(".score_box .score_text").innerHTML = tag;
}