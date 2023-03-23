import { Vehicle } from "./Vehicle";
import { Point } from "./Point";

// TAXİYİ DIŞARIYA AÇMAK İÇİN EXPORT DEMEMİZ GEREKİYOR yani artık taxi sınıfını Taxi.ts dosyası dışında da kullanabiliirz

// bir nesneye ihtiyacımız var bu nesneyi üretebilmek içinde interfaceleri kullanan bir classa ihtiyacımız var
// taxi ve bus aslında bir araç araç için tanımladığımız özellikleri barındırır
export class Taxi implements Vehicle{
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
