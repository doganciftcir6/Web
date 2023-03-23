using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
     class VeriTipiDonusumu
    {
        static void Main(string[] args)
        {
            //implicit casting (automatically): smaller type to larger bilinçsiz tür dönüşümü
            // int-long-float-double küçükten büyüğe veri aktarımı sırasında herhangi işlem yapmak gerekmiyor
            int a = 10;
            long b = a;

            float e = 10.5f;
            double f = e;

            //explicit castin (manually): larger type to smallar bilinçli tür dönüşümü
            long c = 10;
            int d = (int)c;

            double g = 10.6;
            float h = (float)g;

            double k = 10.5;
            int l = (int)k;

            int m = 2343543;
            byte n = (byte)m;

            //int to string
            int x = 10;
            string z = x.ToString();

            //neden tür dönüşümüne ihtiyaç duyarız
            Console.WriteLine("1.sayı: ");
            int sayi1 = int.Parse(Console.ReadLine()); //readline satırı okur okuduğu değeri ise geriye string olarak aktarıyor ve kullancının konsola değer girmesini yazmasını sağlıyor
            Console.WriteLine("2.sayı: ");
            int sayi2 = int.Parse(Console.ReadLine());
            //2 tane sayıyı kullanıcan aldık şimdi basit bir toplama işlemi yapalım
            int toplam = sayi1 + sayi2;
            //konsola yazdırırken interpolaşın kullanabiliriz $ {} ile
            Console.WriteLine($"girilen toplam değer: {toplam}");
            //sayıları girdiğimizde atıyorum 10 20 girmiş olalım sonuç 1020 olarak gelir çümkü readline geriye string değer döndürüyor dolayısıyla sayıları int değere çevirmemiz lazım int.Parse aracılığıyla yapabiliriz
            //alternatif olarak short.Parse long.Parse var
            //önemli olarak düşük kapastiteli bir tipi yüksek kapasiteli bir tipe dönüştüremeyiz


        }



    }
}
