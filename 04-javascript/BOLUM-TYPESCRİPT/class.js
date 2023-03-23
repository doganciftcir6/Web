// bir nesneye ihtiyacımız var bu nesneyi üretebilmek içinde interfaceleri kullanan bir classa ihtiyacımız var
// taxi ve bus aslında bir araç araç için tanımladığımız özellikleri barındırır
var Taxi = /** @class */ (function () {
    function Taxi() {
    }
    Taxi.prototype.travelTop = function (point) {
        console.log("taksi x: ".concat(point.x, " Y:").concat(point.y, " konumuna gidiyor"));
    };
    return Taxi;
}());
var Bus = /** @class */ (function () {
    function Bus() {
    }
    Bus.prototype.travelTop = function (point) {
        console.log("otob\u00FCs x: ".concat(point.x, " Y:").concat(point.y, " konumuna gidiyor"));
    };
    return Bus;
}());
