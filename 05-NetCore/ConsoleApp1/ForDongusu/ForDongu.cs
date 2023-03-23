using System;

namespace ForDongusu
{
    class ForDongu
    {
        static void Main(string[] args)
        {
            //döngüler
            //for
            //herhangi bir döngü kullanmıyor olsak 1 den 5 e kadar sayıları yazdırmaya kalksak
            Console.WriteLine(0);
            Console.WriteLine(1);
            Console.WriteLine(2);
            Console.WriteLine(3);
            Console.WriteLine(4);
            Console.WriteLine(5);
            //bunu 50 ye kadar olan sayıları yazdırmaya kalksak tek tek böyle yazarak olduça zorlanırız bu yüzden bu gibi tekrarlayan işlemlerde döngüleri kullanıyor olmamız gerekiyor
            //50 ye kadar olan sayıların sadece çift olanlarını toplaya toplaya yazdıralım
            //FOR DÖNGÜSÜNÜN BÖLÜMLERİ İLK ÖNCE BAŞLANGIÇ DEĞERİ SONRA KONTROL SONRA KONTROL DEĞİŞKENİNİN ARTIŞ MİKTARI
            //FOR DÖNGÜSÜNÜN ÇALIŞMASI İÇİN KONTROL KISMINDA TRUE BİLGİSİ DÖNMELİ
            int toplam = 0;
            for (int i = 0; i <= 50; i++)
            {
                if (i % 2 == 0)
                {
                toplam += i;
                Console.WriteLine(toplam);
                }
            }
            //dizi üzerinde for döngüsü
            string[] isimler = { "ada", "yiğit", "sena", "çınar" };
            //isimlerin hepsini ekrana yazdırmak
            for (int i = 0; i < isimler.Length; i++)
            {
                //Index numaraları bana i bilgisiyle gelir
                Console.WriteLine(isimler[i]);
            }



            //while
            //do-while
            //foreach
        }
    }
}
