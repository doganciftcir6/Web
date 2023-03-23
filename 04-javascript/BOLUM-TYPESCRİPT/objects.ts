// bu şekilde yazmak yerine bir interface tanımlayabiliriz
interface Point {
    x: number,
    y: number
}

interface Vehicle5{
    // x ve ye özellikleri olan aracın konumunu verecek olan Point türünde tanımlayabiliriz
    currentLocation: Point;
    // metoduda burada tanımlayabilirim gövde belirtmiyoruz metotun şemasını belirtiyoruz sadece
    // ne parametre gelecek bu metota ve metot geriye ne döndürecek bunları belirtiyoruz
    travelTo(point: Point): void;
}

// bir nesneye ihtiyacımız var bu nesneyi üretebilmek içinde interfaceleri kullanan bir classa ihtiyacımız var
// taxi ve bus aslında bir araç araç için tanımladığımız özellikleri barındırır
class Taxi5 implements Vehicle5{
    currentLocation: Point;
    travelTo(point: Point): void {
        console.log(`taksi x: ${point.x} Y:${point.y} konumuna gidiyor`);
    }
}
class Bus5 implements Vehicle5 {
    currentLocation: Point;
    travelTo(point: Point): void {
        console.log(`otobüs x: ${point.x} Y:${point.y} konumuna gidiyor`);
    }

}

// nesne üretelim
let taxi_5: Taxi5 = new Taxi5();
taxi_5.travelTo({x:1, y:2});

taxi_5.currentLocation = {x:2,y:3};

// başka nesne üretelim
let taxi_2 = new Taxi5();
taxi_2.travelTo({x:5,y:6});
taxi_2.currentLocation = {x:4, y:8};

//bus nesnesi üretelim
let bus_1 = new Bus5();
bus_1.travelTo({x:5,y:7});
bus_1.currentLocation = {x:4, y:8};