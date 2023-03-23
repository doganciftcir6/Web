using System;

namespace UygulumaWhileDongusu
{
    class UygulamaWhile
    {
        static void Main(string[] args)
        {
            //ürün adetini kullanıcı belirlesin
            //sınırsız sayıda ürün ismini bir dizi içinde saklayın
            Console.WriteLine("Adet bilgisini giriniz: ");
            int adet = int.Parse(Console.ReadLine());
            string[] urunler = new string[adet];
            //eklenen ürünler listelensin
            int i = 0;

            do
            {
                Console.WriteLine("ürün adı");
                urunler[i] = Console.ReadLine();
                i++;
            } while (adet != i);
            Console.WriteLine("ürünler listeleniyor...");
            for(int a = 0; a < urunler.Length; a++)
            {
                Console.WriteLine(urunler[a]);
            }

            
            

            //while,array
            //string[] => 5
            //class => name,price,description
        }
    }
}
