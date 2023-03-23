using System;

namespace UygulamaForDongusu
{
    class UygulamaForDongusu
    {
        static void Main(string[] args)
        {
            //1- Kullanıcıdan başlangıç, bitiş ve artış miktarı alınarak aralıktaki tüm sayıları ekrana yazdırınız
            Console.WriteLine("Başlangıç miktarını giriniz: ");
            int baslangicMiktari = int.Parse(Console.ReadLine());
            Console.WriteLine("Bitiş miktarını giriniz: ");
            int bitisMiktari = int.Parse(Console.ReadLine());
            Console.WriteLine("Artış miktarını giriniz: ");
            int artisMiktari = int.Parse(Console.ReadLine());

           for( ;baslangicMiktari < bitisMiktari ; baslangicMiktari += artisMiktari)
            {
                Console.WriteLine(baslangicMiktari);
            }

            Console.WriteLine("AYRILIN ULENNNNNNNNNNNNNNN****************************************************");
            int[] sayilar = { 1, 2, 3, 4, 5, 6, 7, 23, 67, 90 };
            //2- sayilar dizisindeki hangi sayılar 3'ün katıdır
            for(int i = 0; i < sayilar.Length; i++)
            {
                if (sayilar[i] % 3 == 0)
                {
                    Console.WriteLine(sayilar[i]);
                }
            }
            Console.WriteLine("AYRILIN ULENNNNNNNNNNNNNNN****************************************************");
            //3- sayilar dizisindaki sayıların toplamı kaçtır ve çarpımları
            int toplam = 0;
            int carpim = 1;
            for (int i = 0; i < sayilar.Length;i++)
            {
                toplam += sayilar[i];
                carpim *= sayilar[i];
            }
            Console.WriteLine("sayıların toplamı: " + toplam + "ve çarpımları: " + carpim);

            //4- sayilar dizisindeki tek sayıların karesini ekrana yazdırınız
            Console.WriteLine("AYRILIN ULENNNNNNNNNNNNNNN****************************************************");
            for(int i = 0; i < sayilar.Length; i++)
            {
                if(sayilar[i] % 2 == 1)
                {
                    Console.WriteLine(Math.Pow(sayilar[i],2));
                }
            }
            string[] arabalar = {"Opel","Mazda","Toyota","Bmw","Mercedes"};
            //5- arabalar dizisindeki en az 5 karakterli araç isimlerini yazdırın.
            Console.WriteLine("AYRILIN ULENNNNNNNNNNNNNNN****************************************************");
            for (int i = 0; i < arabalar.Length; i++)
            {
                if(arabalar[i].Length >= 5)
                {
                    Console.WriteLine(arabalar[i]);
                }
            }
        }
    }
}
