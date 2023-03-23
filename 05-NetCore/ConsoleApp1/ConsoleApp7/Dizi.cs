using System;

namespace ConsoleApp7
{
    class Dizi
    {
        static void Main(string[] args)
        {
            //string bir ifadede aslında dizi
            //Split metotu geriye bir dizi gönderiyordu bunu kullanalım
            string msg = "Hello There. My name is Dogan Ciftci";
            Console.WriteLine(msg[0]);
            Console.WriteLine(msg[1]);
            Console.WriteLine(msg[2]);
            Console.WriteLine(msg[3]);
            //bu durumda her bir kelimeyi değilde karakteri 0ıncı indexten itibaren saymaya başlar yani hello kelimesinin karakterlerinden itibaren ekrana yazdırmaya başlar

            var result = msg.Split();
            //dizi elemanlarını yazdırmak için
            //bu durumda her bir karakteri değilde kelimeyi ekrana yazdırcaktır
            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
            Console.WriteLine(result[2]);
            Console.WriteLine(result[3]);

            //kendi dizimizi oluşturalım
            //kaç tane eleman geleceğini burada new string dedikten sorna [] içerisinde belirtiyoruz 5 eleman gelecek mesela
            string[] isimler = new string[5];
            //daha sonra bilgilerimizi index numaraları aracılığıyla tek tek atabiliriz
            isimler[0] = "Ahmet";
            isimler[1] = "Çınar";
            isimler[2] = "Ada";
            isimler[3] = "Yiğit";
            isimler[4] = "Sena";
            //elemanalrı alma
            Console.WriteLine(isimler[2]);

            int[] numaralar = new int[5];
            numaralar[0] = 101;
            numaralar[1] = 102;
            numaralar[2] = 103;
            numaralar[3] = 104;
            numaralar[4] = 105;
            Console.WriteLine($"öğrenci adı: {isimler[0]} ve numara: {numaralar[0]}");
            Console.WriteLine($"öğrenci adı: {isimler[1]} ve numara: {numaralar[1]}");
            Console.WriteLine($"öğrenci adı: {isimler[2]} ve numara: {numaralar[2]}");
            Console.WriteLine($"öğrenci adı: {isimler[3]} ve numara: {numaralar[3]}");
            Console.WriteLine($"öğrenci adı: {isimler[4]} ve numara: {numaralar[4]}");
            //bu şekilde 200 elemanı yazdırmak zor bunun için döngüleri kullanıcaz

            //dizileri daha kolay bir şekilde tanımlamak
            string[] isimler2 = { "Ahmet", "Çınar", "Ada", "Yiğit", "Sena" };
            int[] numaralar2 = {101, 102, 103,104,105};

        }
    }
}
