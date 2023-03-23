// bu şekilde yazmak yerine bir interface tanımlayabiliriz
interface Point {
    x: number,
    y: number
}
// Passenger interfacesini tanımlayalım
interface Passenger{
    name: string;
    phone: string;
}
// bir interface daha tanımlayalım araç anlamına gelen
// BU İNTERFACE SADECE ÜRETİCEK OLAN BİLGİLERİN BİR İMZASINI PLANINI TAŞIYOR SADCE ARACIN O ANKİ POZİSYONU YA DA HANGİ NOKTAYA GİDECEĞİ YA DA NOKTALAR ARASI MESFAYEİ ÖLÇMEK YA DA ARACA BİR YOLCU EKLEMEK YADA SİLMEK
interface Vehicle{
    // x ve ye özellikleri olan aracın konumunu verecek olan Point türünde tanımlayabiliriz
    currentLocation: Point;
    // metoduda burada tanımlayabilirim gövde belirtmiyoruz metotun şemasını belirtiyoruz sadece
    // ne parametre gelecek bu metota ve metot geriye ne döndürecek bunları belirtiyoruz
    travelTo(point: Point): void;
    // ikinci metot
    getDistance(pointA: Point, pointB: Point):number;
    // araca binecek olan kişileri belirtelim
    addPassenger(passenger: Passenger):void;
    // araçtan kiş silecek metot
    removePassenger(passenger: Passenger):void;
}



// TÜM BUNLARI BÖYLE TEK TEK TANIMLAMAK YERİNE BİR İNTERFACE İÇERİSİNDE TANIMLARIZ
// // elimizde bir metot olsun
// // verilen kordinatlara göre bir yere gitmemizi sağlayan metot
// // metotta birden çok parametremiz olabilir o yüzden tek tek parametre göndermek yerine bir obje gönderdiğimizi düşünelim
// // artık interface tanımladığımıza göre interfacei burda kullanabikiirz
// let travelTo = (point: Point) => {

// }
// // ekstra bir metot eklemiş olsak mesaafe ölçen bir metot olsun
// let getDistance = (pointA:Point, pointB:Point) =>{

// }
// // metotu kullanırken
// travelTo({
//     x: 1,
//     y: 2
// });