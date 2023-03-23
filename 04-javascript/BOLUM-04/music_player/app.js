// elementlere konumlanalım
const container = document.querySelector(".container");
const image = document.querySelector("#music-image");
const title = document.querySelector("#music-details .title");
const singer = document.querySelector("#music-details .singer");
const prev = document.querySelector("#controls #prev");
const play = document.querySelector("#controls #play");
const next = document.querySelector("#controls #next");
const duration = document.querySelector("#duration-time");
const currentTime = document.querySelector("#current-time");
const progressBar = document.querySelector("#progress-bar");
const volume = document.querySelector("#volume");
const volumeBar = document.querySelector("#volume-bar");
const ul = document.querySelector("ul");







// MusicPlayer sınıfından bir nesne oluşturucaz ve oluşturmuş olduğumuz musicListi içerisine vericez
const player = new MusicPlayer(musicList);


// almış olduğumuz music bilgisini sayfa üzerine direkt yansıtabiliriz
// sayfa yüklendiğinde diyoruz load ile
window.addEventListener("load", () => {
    // getMusic metotunu çağıralım bu sayede birinci music bilgisi ekrana yazdırılır
    let music = player.getMusic();
    // ayrıca displayMusic fonksiyonunuda burada çağırıyor olalımki ekrana o bilgiler gelsin sayfa yüklendiğinde
    displayMusic(music);
    // müzik listesi kısmı için sayfa yüklendiği anda listeyi set etmiş olalım
    displayMusicList(player.musicList);
    // sayfa yüklendiği anda çalan müzikte renk değimi olması için fonksiyonu çağıralım
    isPlayingNow();
});

// displayMusic fonksiyonunu tanımlayalım
// bu sayede music ismi şarkıcısı resmi ve music dosyası ekrana gelmiş olsun
function displayMusic(music){
    title.innerText = music.getName(); 
    singer.innerText = music.singer;
    image.src = "img/" + music.img;
    audio.src = "mp3/" + music.file;
}

// play iconuna etiketine ulaşıp play metotu ile bunu çaldırabiliriz
play.addEventListener("click", () => {
    // music çalıyor mu çalmıyor mu diye boolean türünde bir sabit tanımlıcaz
    const isMusicPlay = container.classList.contains("playing");
    // artık kontrol altında tutabiliriz çalıyorsa durdur çalmıyorsada başlat
    // YANİ PLAYİNG VARSA DURDULUR YOKSA BAŞLATILIR
    isMusicPlay ? pauseMusic() : playMusic();
    // 
});

// şarkı değişitmeyi sağlayan play ve next iconlarımıza işlevsellik kazandıralım
prev.addEventListener("click", () => {
    // prevMusic fonksiyonunu çağıralım
    prevMusic();
});
next.addEventListener("click", () => {
    // prevMusic fonksiyonunu çağıralım
    nextMusic();
});
// prevMusic fonksiyonunu oluşturalım bizi bir önceki müziğe geçirmiş olsun
function prevMusic(){
    // player nesnesindeki prev metotunu çağıralım 
    player.prev();
    // daha sonra muzik bilgisini tekrar alalım ve çalıştıralım
    let music = player.getMusic();
    displayMusic(music);
    playMusic();
    // bir önceki müziğe geçiş olduğu anda çalan müzikte renk değimi olması için fonksiyonu çağıralım
    isPlayingNow();
}
// nextMusic fonksiyonunu oluşturalım bizi bir sonraki müziğe geçirmiş olsun
function nextMusic(){
    // player nesnesindeki prev metotunu çağıralım 
    player.next();
    // daha sonra muzik bilgisini tekrar alalım ve çalıştıralım
    let music = player.getMusic();
    displayMusic(music);
    playMusic();
    // bir sonraki müziğe geçiş olduğu anda çalan müzikte renk değimi olması için fonksiyonu çağıralım
    isPlayingNow();
}

// şimdi kontrol için eklediğimiz fonksiyonları tanımlayalım 2 farklı fonksiyon tanımladık
function pauseMusic(){
    // yani muzik çalarken containerda playing classı olduğu için play tuşuna basılırsa isMusicPlay true değer döndürür ve pauseMusic fonksiyonunu çalıştırır ve music durur YANİ PLAYİNG VARSA DURDULUR YOKSA BAŞLATILIR
    container.classList.remove("playing");
    // pausa tıkladığımız anda icon değişsin
    play.querySelector("i").classList = "fa-solid fa-play";
    audio.pause();
}
function playMusic(){
    // yani muzik çalmazken containerda playing classı olmadığı için play tuşuna basılırsa isMusicPlay false değer döndürür ve platMusic fonksiyonunu çalıştırır music başlar YANİ PLAYİNG VARSA DURDULUR YOKSA BAŞLATILIR
    container.classList.add("playing");
    // playa tıkladığımız anda icon değişsin
    play.querySelector("i").classList = "fa-solid fa-pause";
    audio.play();
}

// progress bar yani müzik süre barı kısmı
// fonkstion tanımlayalım bu fonksiyon toplam saniyeyi alsın dakikaya çevirsin ancak küsüratlar olmasın düz 3 e çevirsin ondan floor ve bu fonksiyonda saniye bilgisi de olsun
const calculateTime = (toplamSaniye) => {
    const dakika = Math.floor(toplamSaniye / 60);
    const saniye = Math.floor(toplamSaniye % 60);
    const guncellenenSaniye = saniye < 10 ? `0${saniye}`:`${saniye}`;
    const sonuc = `${dakika}:${saniye}`;
    return sonuc;
}
// süre bilgisini alalım
audio.addEventListener("loadedmetadata", () => {
    duration.textContent = calculateTime(audio.duration);
    // saniye süre kısımları tamam şimdi progressbarı ayarlıyor olalım
    progressBar.max = Math.floor(audio.duration);
});
// geçen süreyi progressBarın üzerinde gösterelim
// timeupdate yani saniye geçtiği sürece burası çalıştırılacak
audio.addEventListener("timeupdate", () =>{
    progressBar.value = Math.floor(audio.currentTime);
    currentTime.textContent = calculateTime(progressBar.value);
});
// kullanıcı progressbarın herhangi bir yerine tıkladığında müzik saniyesi ilerlesin veya azalsın kısmı
// input ile progressbara her tıklama anımda içerideki kodlar çalıştırıalcak input anında yani
progressBar.addEventListener("input", () => {
    currentTime.textContent = calculateTime(progressBar.value);
    // müziğin süre bilgisi set edilsin
    audio.currentTime = progressBar.value;

});

// ses açma kısma kısmını yapıcaz
let sesDurumu = "sesli";
// volume bara tıklandığında ses kullanıcının tıklamasına göre ayarlansın
volumeBar.addEventListener("input", (e) =>{
    const value = e.target.value;
    // ses bilgisini aldık nereye vericez 100 e bölerek 1 ile 0 arasında bir değer göndermemiz gerekir yoksa çalışamz
    audio.volume = value / 100;
    // sliderda 0 a gelindiğinde iconun değişmesi gerekiyor ve tekrar sesi açıldığında da icon değişmesi gerekiyor
    if(value == 0){
        // mutedın true olması sesin kısılması demek
        audio.muted = true;
        sesDurumu = "sessiz";
        // tıklandığında iconda değişsin
        volume.classList = "fa-solid fa-volume-xmark";
    }else{
        audio.muted = false;
        sesDurumu = "sesli";
        // tıklandığında iconda değişsin
        volume.classList = "fa-solid fa-volume-high";
    }
});

// icona tıklandığında ses gitsin veya gelsin
volume.addEventListener("click", () => {
    if(sesDurumu === "sesli"){
        // mutedın true olması sesin kısılması demek
        audio.muted = true;
        sesDurumu = "sessiz";
        // tıklandığında iconda değişsin
        volume.classList = "fa-solid fa-volume-xmark";
        // sustuğu durumda sliderı çalıştırlaım sessizken en başta
        volumeBar.value = 0;
    }else{
        audio.muted = false;
        sesDurumu = "sesli";
        // tıklandığında iconda değişsin
        volume.classList = "fa-solid fa-volume-high";
        // sustuğu durumda sliderı çalıştırlaım sesliyken en sonda
        volumeBar.value = 100;
    }
});

// müzik listesi kısmı için displayMusicList fonksiyonunu oluşturalım
const displayMusicList = (list) => {
    // liste üzerindeki her bir elemanı dolaşalım
    for(let i=0; i < list.length; i++) {
        // liste elemanına tıklandığında müziğin başlaması kısmı için li etiketine onclick eventini ekledik ayrıca li-index isminde parametre tanımladık her bir elemanı indeks nuamrasına göre ayırmış olduk 0 1 2 şeklinde gider
        let liTag = `
            <li li-index='${i}' onclick="selectedMusic(this)" class="list-group-item d-flex justify-content-between align-items-center">
                <span>${list[i].getName()}</span>
                <span id="music-${i}" class="badge bg-primary rounded-pill"></span>
                <audio class="music-${i}" src="mp3/${list[i].file}"></audio>
            </li>
        `;

        ul.insertAdjacentHTML("beforeend", liTag);
        // her bir müziğin kendi süresini yazdıralım
        let liAudioDuration = ul.querySelector(`#music-${i}`);
        let liAudioTag = ul.querySelector(`.music-${i}`);

        // bunları nereye aktarıcaz
        liAudioTag.addEventListener("loadeddata", () => {
            liAudioDuration.innerText = calculateTime(liAudioTag.duration);
        });

    }
}
// liste elemanına tıklandığında müziğin başlaması kısmı
const selectedMusic = (li) => {
    // herhangi bir müziğe tıkladığımız anda müziğin index numarası bu sayede gelecektir
    player.index = li.getAttribute("li-index");
    // müziği başlatalım index numarasına göre
    displayMusic(player.getMusic());
    playMusic();
    // liste elemanı tıklayınca renk değimi olması için fonksiyonu çağıralım
    isPlayingNow();
}
// listede müziğe tıklandığında renk değişimi olsun dolayısıyla li.playing classını ekleyecek olan bi fonksiyon tanımlıcaz
const isPlayingNow = () => {
    // bütün elemanları gezicez
    for(let li of ul.querySelectorAll("li")){
        if(li.classList.contains("playing")){
            li.classList.remove("playing");
        }
        if(li.getAttribute("li-index") == player.index){
            li.classList.add("playing")
        }
    }
}
// müzik bittiğinde bir sonraki müziğe geçsin kısmı
audio.addEventListener("ended", () => {
nextMusic();
});