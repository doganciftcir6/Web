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
class Taxi9 implements Vehicle2{
     // aracın rengini tutacak olan bilgi olsun
     private color: string;
     // değişken konum bilgisini veren
     currentLocation: Point;
    // konstraktır sayesinde nesne üretirken bir parametre girmesini zorunda bırakıyoruz konstraktır içinde de private tanımlama yapabiliyoruz private color: any gibi bu sayede yukarıda private color:string diye tanımlama yapmaya gerek kalmıyor
    constructor(private location: Point, color?: any){
        this.currentLocation = location;
        this.color = color;
    }
    // metot
    travelTo(point: Point): void {
        console.log(`taksi x: ${this.location.x} Y:${this.location.y} konumuna gidiyor`);
    }
}

// nesne üretelim
let taxi_9: Taxi9 = new Taxi9({x:5, y:4}, 'Red');
taxi_9.travelTo({x:1, y:2});
// // color bilgisini burada güncelleyebiliriz veya konstraktır ile yapabiliriz yanlız konstraktırda ? opitonal koyarsak bunu girmek zorunda değiliz nesne üretirken
// yalnız konstraktır kullandığımızda bu değişkenlere vs böyle dışarıdan direkt olarak ulaşamamız lazım ondan private yaparız
// taxi_1.color = 'red';

// başka nesne
let taxi_7 = new Taxi9({x:3,y:7});
// private olduğu için artık .color bilgisine ulaşamıyoruz