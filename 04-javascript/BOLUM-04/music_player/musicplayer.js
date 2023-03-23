// musicle ilgili metotları içeren

// bir class oluşturulaım
class MusicPlayer {
    // konstraktır
    constructor(musicList) {
        this.musicList = musicList;
        // ben MusicPlayerdan bir nesne oluşturduğum anda index bilgisi 1 a eşitlensin
        this.index = 1;
    }
// bir metot bu metot bize o anda music listesi içerisinden index numarasındaki music bilgisini bana getirsin
    getMusic() {
        return this.musicList[this.index];
    }
// next metotu ile bir sonraki music bilgisi gelecek
    next() {
        // bunun için index nuamrasını bir arttıyor olması gerekiyor tabi bunu kontrollü yapmamız lazım
        if(this.index + 1 < this.musicList.length) {
            this.index++;
        }
        else { //else durumunda music bilgisi başa dönecek bu şekilde
             this.index = 0;
        }
    }
 // previous metotu ile bir önceki music bilgisi gelecek
    prev() {
        if(this.index != 0) {
            this.index--;
        } else { //else durumunda index nuamrası olarak 0 a gelmişsem en sondaki müziğe geçiş yapmış olalım
            this.index = this.musicList.length - 1;
        }
    }
}