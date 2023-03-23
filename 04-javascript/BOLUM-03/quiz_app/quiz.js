// quiz ile alakalı olan scriptler

// bir quiz konsraktırı yapalım
function Quiz(sorular){
    this.sorular = sorular;
    this.soruIndex = 0;
    // skor bilgisi kısmı için doğru cevap sayısını tutacak bir değişken
    this.dogruCevapSayisi = 0;
}
// bir fonksiyon eklicez fakat bunu konstraktır içinde değil dışarıda protype aracılığıyla tanımlıcaz daha performanslı bir uygulama olsun
Quiz.prototype.soruGetir = function(){
  return this.sorular[this.soruIndex]
}