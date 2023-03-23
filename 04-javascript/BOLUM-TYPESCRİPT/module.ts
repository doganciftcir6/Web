
// Taxi.ts dosyasındaki Taxi sınıfını kullanmak için import edicez
import {Taxi} from './Taxi';
import {Bus} from './Bus';






// nesne üretelim
let taxi_13: Taxi = new Taxi({x:5, y:4}, 'Red');
taxi_13.travelTo({x:1, y:2});
// // color bilgisini burada güncelleyebiliriz veya konstraktır ile yapabiliriz yanlız konstraktırda ? opitonal koyarsak bunu girmek zorunda değiliz nesne üretirken
// yalnız konstraktır kullandığımızda bu değişkenlere vs böyle dışarıdan direkt olarak ulaşamamız lazım ondan private yaparız
// taxi_1.color = 'red';

// başka nesne
let taxi_14 = new Taxi({x:3,y:7});
// private olduğu için artık .color bilgisine ulaşamıyoruz

// PRİVAT OLDUĞUNDA GET SET
// locaiton bilgisini alabiliriz get ile
let currentLocation2 = taxi_14.Location;
// burda bir atama işlemi yapabilirz set ile
taxi_14.Location = {x:2,y:6};