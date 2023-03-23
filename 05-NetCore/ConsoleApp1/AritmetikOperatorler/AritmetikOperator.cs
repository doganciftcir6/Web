using System;

namespace AritmetikOperatorler
{
    class AritmetikOperator
    {
        static void Main(string[] args)
        {
            //Operatörler

            //1- Aritmetik Operatörler (+,-,*,/,%,++,--)
            int a = 10;
            int b = 20;
            int val;

            val = a + b;  //30
            val = a - b;  //-10
            val = a * b;  //200
            val = a / b;  //0
            val = b % a;  //5%2=>1 | 0
            val = a++;    //arttırma işlemi olmadan önce atama yapılır sorna değer arttırılır mesela a nın içeriğini b ye aktarıyor olalım  a 10 olsun bu şekilde önce b ye 10 gider sonra a 11 olur kendisi
            val = ++a;    //ilk başta değer arttırılır sonra atama işlemi yapılır bu sayede a da b de 11 olur
            val = a--;
            val = --a;

            Console.WriteLine("value: " + val);

            //2- Atama Operatörleri (=, +=,-=,*=,/=,%=)
            int x = 5, y=10, z=20;
            double val2;

            x += 5; //x = x + 5;
            x -= 5; //x = x - 5;
            x *= 5; //x = x * 5;
            x /= 5; //x = x / 5;
            x %= 5; //x = x % 5;
            //kare alma 2 üzeri 5 demiş oluruz
            val2 = Math.Pow(2,5);
            //karekök alabiliirz .Sqrt ile bu durumda bize 5 değeri gelcektir
            val2 = Math.Sqrt(25);
            //mutlak değer .Abs pozitif 10 döner
            val2 = Math.Abs(-10);
            //.Round() ile yuvarlama yapabiliriz 4 e yuvarlar yani en yakın tam sayıya 4.6 girsek 5 e yuvarlar eğer 5.5 gibi tam ortada olan bir sayı olursa en yakın çift sayıya yuvarlama yapar 6 ya yani
            val2 = Math.Round(4.4);
            //.Ceiling metotu her zaman yukarıya yuvarlama yapar 5.3 ü 6 ya yuvarlar mesela
            val2 = Math.Ceiling(5.3);
            //.Floor() metotu her zaman aşağıya yuvarlama yapar 5.6 yı 5 e yuvarlar mesela
            val2 = Math.Floor(5.6);

            Console.WriteLine(val2);
            Console.WriteLine($"x: {x} y: {y} z: {z}");

            //3- Karşılaştırma Operatörleri (==, !=, <, >, <=, >=, ?:)
            int a2 = 5, b2 = 5, c2 = 10, d2 = 4;
            string username = "doganciftci";
            string password = "123456";

            var result = (a2 == b2); //a b ye eşit mi true yada false döner 
            result = (a2 == c2);   // a c ye eşit mi
            Console.WriteLine(result);
            //string ifadelerde karşılaştırma
            result = (username == "sdktrn");  //username değişkeni "sdktrn" a eşit mi true yada false yine
            result = (password == "123456");

            result = (a2 != b); // a b ye eşit değil mi eğer eşit olursa false döndürür eşit değilse true
            result = (a2 > b2); //a b den büyük mü true ya da false
            result = (a2 >= b2); //a b den büyük veya eşit mi
            result = (a2 <= b2); //a b den küçük eşit mi

            //koşul ifadeleri için ? oparetörü kullanabiliirz eğer dönecek olan cevap true ise ? operatoründen sonra ilk tırnaklar false ise ikinci tırnaklar işletilir : nın sol tarafı true sağ tarafı false için çalışır yani
            string sonuc2 = (a == b) ? "a=b" : "a!=b";
            //veya
            sonuc2 = (username == "sdktrn") ? "username doğru" : "username yanlış";
            //iki koşulu birleştirebiliyirouz
            sonuc2 = (username == "sdktrn") ? (password == "123456") ? "username ve parola doğru" : " username doğru ve parola yanlış" 
                                                                         :
                                              (password == "123456") ? "username yanlış parola doğru" : "username yanlış parola yanlış";


            Console.WriteLine(sonuc2);

            //4-Mantıksal Operatörler(&&,||,!)

            //(&&) and
            //true && true => true
            //true && false => false
            //false && false => false
            int x4 = 5;

            int hak = 5;
            char devammi = 'e';
            var result6 = (x > 5);
            //5<x<10 aralık istiyorum yani
            result6 = (x > 5) && (x < 10);
            result6 = (hak > 0) && (devammi == 'e');

            //(||) or
            //true && true => true
            //true && false => true
            //false && false => false
            result6 = (x4 > 0) || (x4 % 2 == 0);

            // not (!)
            // true => false
            // false => true
            result6 = !(x > 0);

            //and or opatarotlerini beraber kullanalım
            //x, 5-10 arasında olan bir çift sayı mıdır
            result6 = ((x4 > 5) && (x4 < 10)) && (x % 2 == 0); //(true && true) && true

            Console.WriteLine(result);

        }
    }
}
