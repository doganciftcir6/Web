using System;

namespace ConsoleApp8
{
    class DiziMetot
    {
        static void Main(string[] args)
        {
            //Bir dizimiz olsun
            string[] isimler = { "Ahmet", "Çınar", "Ada", "Yiğit", "Sena" };
            int[] numaralar = { 5, 3, 6, 1, 2 };
            //isimler dizisinin her bir elemanına ulaşmak
            Console.WriteLine(isimler[0]);
            //isimler dizisine bir eleman ataması yapmak
            isimler[0] = "Ali";

            //eleman atamasına alternatif olarak .SetValue() isminde metot var Ali bilgisini 0ıncı indexe ata diyebiliriz
            isimler.SetValue("Ali", 0);

            //.GetValue() ile 0 ıncı indexteki eleman diyoruz ve 0ıncı indexteki elemanı bize verir
            Console.WriteLine(isimler.GetValue(0));

            //dizi içerisinde herhangi bir elemanın index numarasını merak ediyorusam Array.IndexOf() metotu içerisine önce dizimizi veriyoruz sonra aramak istediğimiz ifadeyi veriyoruz ve o ifadenin index değeri geriye dönüyor
            Console.WriteLine(Array.IndexOf(isimler, "Çınar"));

            //dizi içerisinde kaç tane eleman var bunu merak ediyorsam .Lenght özelliğini kullanabilirim bu bir metot değil özellik
            Console.WriteLine(isimler.Length);

            //Array.Sort isimler dizisini alfabetik sıraya göre sıralar A'DAN-Z'YE ilk harfler aynıysa bu sefer ikinci harflere bakar ayrıca dizi komple değişir kalıcı olarak eğer sayılar dizisiyse küçükten büyüğe doğru bir sıralama yapar
            Array.Sort(isimler);
            Array.Sort(numaralar);

            //dizinin elemamlarını ters çevirebiliriz .Reverse() metotu sayesinde eğer en başta Ada varsa o en sona gider en sondaki eleman en başa gelir yani
            Array.Reverse(isimler);

            //dizinin içerisinden bir eleman silmek istersek .Clear() metotu parametre içerisi ise isimler dizisinin 0. indexten itibaren 2 tane eleman sil diyebiliriz ilk 2 elemanı olmuş oluyor yani
            Array.Clear(isimler, 0, 2);

            //dizi soldan sağa doğru baştan sona doğru 0 dan başlar ama sondan başa doğru sağdan sola doğru 1 2 diye başlar
            //^ karakteri ile bunu yapmayı sağlar yani baştan değilde sondan şekilde gerçekleştirir işlemleri burda sondaki elemanı çağırmış oluruz
            Console.WriteLine(isimler[0]);
            Console.WriteLine(isimler[^1]);

            //isimler dizisinin elamnlarını görmek için tek tek yazmak yerine bir foreach kullanabiliirz
            //forach içerisinde var isim diye bir değişken tanımlıyoruz ve isimler dizisinin elemanlarını tek tek sırayla bu değişkenin içerisine kopyalıyoruz
            foreach (var isim in isimler)
            {
                Console.WriteLine(isim);
            }

            //yeni dizi oluşturalım ve dizi elemanları isimler dizisi içerisinden gelsin 1. elemandan itbaren diyoruz ve .. ekliyoruz bu .. nın anlamı bir aralık belirtmiş oluyoruz ve sonra bitiş elemanını verelim ancak 1. ve 4. eleman dehil olmaz
            var result = isimler[1..4];
            //1. elemandan sonra hepsini al diyebiliriz
            var result2 = isimler[1..];
            //baştan başla 4. elemana kadar al diyebiliriz
            var result3 = isimler[..4];
            //stringde de bu olay var 0 dan başla 5 e kadar al diyebiliriz bu durumda bize 0 da n başlar 5. karaktere kadar alır ancak 5 dahil olmuyor
            string msg = "Hello There";
            Console.WriteLine(msg[0..5]);


        }
    }
}
