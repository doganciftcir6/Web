// müzikle alakalı bilgiler

// bir class oluşturucaz
class Music{
    // konstraktır
    // her bir mp3 bilgisinin titleı
    constructor(title, singer, img, file){
        this.title = title;
        this.singer = singer;
        this.img = img;
        this.file = file;
    }
    // metotlar
    // getname metotu çağrılınca şarkı ve şarkıcı ismi geitrecek
    getName(){
        return this.title + " - " + this.singer
    }
}

// müsic listesini burada ekleyelim tabi bunu database den vs alıcaz sonraki zamanlarda
// müsicList diye bir dizi ve içine yukarıdaki Music sınıfımızdan nesneler
const musicList = [
    new Music("Boşver", "Nilüfer", "1.jpeg", "1.mp3"),
    new Music("Bu da Geçer mi Sevgilim", "Yalın", "2.jpeg", "2.mp3"),
    new Music("Aramızda Uçurumlar", "Suat Suna", "3.jpeg", "3.mp3")
]