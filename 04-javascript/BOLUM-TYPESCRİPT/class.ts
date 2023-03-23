// bu şekilde yazmak yerine bir interface tanımlayabiliriz
interface Point {
    x: number,
    y: number
}

interface Vehicle3{
    // x ve ye özellikleri olan aracın konumunu verecek olan Point türünde tanımlayabiliriz
    currentLocation: Point;
    // metoduda burada tanımlayabilirim gövde belirtmiyoruz metotun şemasını belirtiyoruz sadece
    // ne parametre gelecek bu metota ve metot geriye ne döndürecek bunları belirtiyoruz
    travelTo(point: Point): void;
}

// bir nesneye ihtiyacımız var bu nesneyi üretebilmek içinde interfaceleri kullanan bir classa ihtiyacımız var
// taxi ve bus aslında bir araç araç için tanımladığımız özellikleri barındırır
class Taxi implements Vehicle3{
    currentLocation: Point;
    travelTo(point: Point): void {
        console.log(`taksi x: ${point.x} Y:${point.y} konumuna gidiyor`);
    }
}
class Bus implements Vehicle3 {
    currentLocation: Point;
    travelTo(point: Point): void {
        console.log(`otobüs x: ${point.x} Y:${point.y} konumuna gidiyor`);
    }

}

