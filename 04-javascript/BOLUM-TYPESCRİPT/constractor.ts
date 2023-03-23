// bu şekilde yazmak yerine bir interface tanımlayabiliriz
interface Point {
    x: number,
    y: number
}

interface Vehicle2{
    // x ve ye özellikleri olan aracın konumunu verecek olan Point türünde tanımlayabiliriz
    currentLocation: Point;
    // metoduda burada tanımlayabilirim gövde belirtmiyoruz metotun şemasını belirtiyoruz sadece
    // ne parametre gelecek bu metota ve metot geriye ne döndürecek bunları belirtiyoruz
    travelTo(point: Point): void;
}

// bir nesneye ihtiyacımız var bu nesneyi üretebilmek içinde interfaceleri kullanan bir classa ihtiyacımız var
// taxi ve bus aslında bir araç araç için tanımladığımız özellikleri barındırır
class Taxi8 implements Vehicle2{
    // konstraktır sayesinde nesne üretirken bir parametre girmesini zorunda bırakıyoruz
    constructor(location: Point, color?: any){
        this.currentLocation = location;
        this.color = color;
    }
    // aracın rengini tutacak olan bilgi olsun
    color: string;
    // değişken konum bilgisini veren
    currentLocation: Point;
    // metot
    travelTo(point: Point): void {
        console.log(`taksi x: ${point.x} Y:${point.y} konumuna gidiyor`);
    }
}

// nesne üretelim
let taxi_1: Taxi8 = new Taxi8({x:5, y:4}, 'Red');
taxi_1.travelTo({x:1, y:2});
// artık konstraktır sayesinde bunu dediğimde hata almam nesenyi üretme aşamasında konstraktır ile location tanımlaması yaptığımız için
console.log(taxi_1.currentLocation);
// // color bilgisini burada güncelleyebiliriz veya konstraktır ile yapabiliriz yanlız konstraktırda ? opitonal koyarsak bunu girmek zorunda değiliz nesne üretirken
// taxi_1.color = 'red';

// başka nesne
let taxi_4 = new Taxi8({x:3,y:7});