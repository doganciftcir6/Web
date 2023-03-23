// bazı değişkenlerimiz olsun operatörlerde kullanmak için
let sonuc;
let a=10, b=2, c=30;

// 1-Arimetik Operatörler
sonuc = a + b; //toplama yapar
sonuc = a - b; //çıkartma yapar
sonuc = a * b; //çarpma yapar
sonuc = a / b; //bölme yapar
sonuc = c % a; //kalanı verir mod alma
sonuc = a++; // a yı bir arttır önce atamayıp yp sonra arttırma işlemini yap
sonuc = ++a; // a ilk başta bir arttırılır arttırıldıktan sonra atama işlemi yapılır
sonuc = a--; // a yı bir azalt önce atamayı yap sonra azaltma işlemini yap
sonuc = --a; // a ilk başta bir azaltılır azaltıldıktan sonra atama işlemi yapılır


// 2-Atama Operatörleri
sonuc = a; //sağ taraftan sol tarafa bir atama işlemi yapılır
sonuc += a; //sonuc = sonuc + a     a ile sonucu topla çıkan hesaplanan değeri tekrar sonuç içerisine ata deriz
sonuc -= a; //sonuc = sonuc - a     a ile sonucu çıkart çıkan hesaplanan değeri tekrar sonuç içerisine ata deriz
sonuc *= a; //sonuc = sonuc - a     a ile sonucu çarp çıkan hesaplanan değeri tekrar sonuç içerisine ata deriz
sonuc /= a; //sonuc = sonuc - a     a ile sonucu böl çıkan hesaplanan değeri tekrar sonuç içerisine ata deriz
sonuc %= a; //sonuc = sonuc - a     a ile sonucu modunu al çıkan hesaplanan değeri tekrar sonuç içerisine ata deriz

// 3-Karşılaştırma Operatörler
sonuc = a == b; //a b ye eşit mi eşitse true döner değilse false
sonuc = a != b; //a b ye eşit değil mi eşit değilse true döner eşitse false
sonuc = (3 === "3"); //eğer bu işlemi iki eşşittir ile yaparsak true değeri gelcektir ama 3 eşittir ile yaparsak burada değer kontrolü dışında bir de tip kontrolüde yapar biri number biri string olduğu için false döner
sonuc = a > b; //a b den büyükse true değilse false döner
sonuc = a < b; //a b den küçükse true değilse false döner
sonuc = a <= b; //a b den küçükse veya eşitse true değilse false döner
sonuc = a >= b; //a b den büyükse veya eşitse true değilse false döner



// 4-Mantıksal Operatörler

console.log(sonuc);