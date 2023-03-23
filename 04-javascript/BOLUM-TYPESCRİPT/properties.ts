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
class Taxi11 implements Vehicle2{
     // aracın rengini tutacak olan bilgi olsun
     private color: string;
     // değişken konum bilgisini veren
     currentLocation: Point;
    // konstraktır sayesinde nesne üretirken bir parametre girmesini zorunda bırakıyoruz konstraktır içinde de private tanımlama yapabiliyoruz private color: any gibi bu sayede yukarıda private color:string diye tanımlama yapmaya gerek kalmıyor
    constructor(private _location: Point, _color?: any){
        this.currentLocation = _location;
        this.color = _color;
    }
    // metot
    travelTo(point: Point): void {
        console.log(`taksi x: ${this._location.x} Y:${this._location.y} konumuna gidiyor`);
    }
    // metot get
    // aynı sınıf içrisinde olduğu için this ile ulaşılabiliyor private olsa bile
    get Location(){
        return this._location;
    }
    // metot set
    // kontrollü bir şekilde atama yapmak için set
    set Location(value: Point){
        if(value.x<0 || value.y < 0){
            throw new Error('koordinat bilgileri negatif olamaz');
        }
        this._location = value;
    }
}

// nesne üretelim
let taxi_12: Taxi11 = new Taxi11({x:5, y:4}, 'Red');
taxi_9.travelTo({x:1, y:2});
// // color bilgisini burada güncelleyebiliriz veya konstraktır ile yapabiliriz yanlız konstraktırda ? opitonal koyarsak bunu girmek zorunda değiliz nesne üretirken
// yalnız konstraktır kullandığımızda bu değişkenlere vs böyle dışarıdan direkt olarak ulaşamamız lazım ondan private yaparız
// taxi_1.color = 'red';

// başka nesne
let taxi_11 = new Taxi11({x:3,y:7});
// private olduğu için artık .color bilgisine ulaşamıyoruz

// PRİVAT OLDUĞUNDA GET SET
// locaiton bilgisini alabiliriz get ile
let currentLocation = taxi_12.Location;
// burda bir atama işlemi yapabilirz set ile
taxi_12.Location = {x:2,y:6};