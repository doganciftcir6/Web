using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kısa ve uzun kenarı girilen dikdörtgenin alan ve çevresini hesaplayınız

            //kullanıcıdan bilgileri alalım
            Console.Write("kısa kenar: ");
            int kisa = int.Parse(Console.ReadLine());
            Console.Write("uzun kenar: ");
            int uzun = int.Parse(Console.ReadLine());

            //kısa ve uzun kenarı kullanıcan aldık ve bir hesaplama işlemi yapıcaz
            //alan hesabı
            //burda tanımlama yaparken int yerine var kullanabiliriz bunu kullandığımız zaman buradaki kisa*uzun dan dönen veri tipi neyse o veri tipi otomatikmen alana atanmış oluyor
            var alan = kisa * uzun;
            //çevre hesabı
            int cevre = (kisa + uzun) * 2;
            //değerleri ekrana yazmamız gerekiyor
            // Console.WriteLine("alan: " + alan + " " + "çevre " + cevre); bunun daha kolay bir yolu var
            Console.WriteLine($"alan: {alan} çevre: {cevre}");

            //var ile değişken tanımlamak
            //burada strnin tipi otomatikmen string olarak atanıyor
            var str = "dogan ciftci";
            // price değişkeninin veri tipi otomatikmen int oldu
            var price = 100;
            // burada ondalıklı bir sayı girince price2 değişkenin veri tipi double oldu otomatikmen
            var price2 = 100.5;
            //ondalıklı sayıya m eklersek veri tipi otomatikmen decimal oluyor
            var price3 = 100.5m;
            //ondalıklı sayıya f eklersek veri tipi otomatikmen float oluyor
            var price4 = 100.5f;

            //uygulamamıza breakpoint ekleyebiliriz soldaki kırmızı yuvarlak tuşa basarak bunu yapma sebebimiz uygulumamızı çalıştırdığımızda breakpoint eklediğimizden itibaren programı adım adım takip edebiliriz



        }
    }
}
