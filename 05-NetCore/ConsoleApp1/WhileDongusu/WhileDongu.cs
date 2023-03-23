using System;

namespace WhileDongusu
{
    class WhileDongu
    {
        static void Main(string[] args)
        {
            //while
            //bunu biliyoruz artık for
            for(int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            //while döngüsü parantezi içersiindeki bilgi true olduğu sürece döngü çalışır yani bir koşul yazmamız gerekir
            //i nin dışarıda tanımlanıyor olması gerekiyor
            //i nin değeri sabit kalmasın diye i yi yine arttırıyor olmam lazım ama bu sefer {} içnide yaparım bunu fordan farklı olarak
            //while içinde if kullanabiliriz sadece çift tek sayıları yazdıralım fakat artış miktarı if kapsamında olmamalı dikkat
            int i = 0;
            while (i < 10)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("sayı çift"+i);
                }
                else
                {
                    Console.WriteLine("sayı tek"+i);
                }
                i++;
            }
            //farklı örnek
            //IsNullOrEmpty boşluk yada null var mı diye kontrol yapıyor varsa true döndürüyor yoks false
            //bu yapıda ben ismime boş bir bilgi girersem yan isimini girmezsem veya ismimi girip boşluk bırakıp başa bir şey girersem bu durumda while parametresine true gelir ve döngü tekrarlanır yine isim sorar
            string name = "";
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("isminiz: ");
                name = Console.ReadLine();
            }
            Console.WriteLine($"Merhaba {name}");


            //do-while
            //bunun farkı kontrolü başta değilde sonda yapıyor olması
            //kulanıca önce ismini soruca isim bilgisini alıcaz ve sonra kontrol edicez
            //eğer gelen bilgi boş ise bu durumda döngü devam etmeye çalışacak
            string name2 = "";
            do
            {
            Console.WriteLine("isminiz: ");
            name = Console.ReadLine();

            } while (string.IsNullOrEmpty(name2));
        }
    }
}
