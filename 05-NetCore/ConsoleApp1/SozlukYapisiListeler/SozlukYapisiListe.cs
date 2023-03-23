using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SozlukYapisiListeler
{
    class SozlukYapisiListe
    {
        static void Main(string[] args)
        {
            //Dictionary<Tkey,Tvalue>

            //list te bir değer içerisine gelecek olan veriler index numaralarına sahip oluyor ancak biz index numaralarını kendimiz belirtmek istersek örneğin
            //burada key bilgisi 34,35 oluyor valuler istanbul,izmir oluyor veben 34 dediğimde bana istanbul bilgisi gelsin istiyorsam
            //plaka => (34: istanbul), (35: izmir)
            //Dictionary Genericttir. Yani Tkey'e gelen ve Tvalue'ye gelen veri tipini burda belirtebiliyoruz <> içinde

            //bir Dictionary tanımlayalım
            Dictionary<int, string> plakalar = new Dictionary<int, string>();

            //bu dictionary içerisine bilgi atmak istediğimizde .Add metotunu kullanabiliriz bizden bir int key bir string value bekler
            plakalar.Add(34, "istanbul");
            plakalar.Add(35, "izmir");
            plakalar.Add(53, "rize");

            //bu tanımlamayı kanstraktır aracılığıyla da yapabiliirz
            Dictionary<int, string> sayilar = new Dictionary<int, string>()
            {
                {1,"Bir" },
                {2,"İki" },
                {3,"Üç" }
            };

            //Sözlük içindeki bilgilere ulaşmak için
            //Buraya 1 yazarsam karşıma "Bir" bilgisi gelir yani 1 key ve onun valuesi Bir yani biz burda index numarası girmiyoruz [] içerisinde key bilgisi giriyoruz value bilgisi geliyor elemanlar index numarasına bağlı değiller
            Console.WriteLine(sayilar[1]);

            //bütün elemanları ekranda yazdırmak
            foreach (var plaka in plakalar)
            {
                Console.WriteLine($"{plaka.Key} {plaka.Value}");
            }
            //foreach yerine for döngüsünü kullanmak istersek
            for (int i = 0; i < plakalar.Count; i++)
            {
                Console.WriteLine($"{plakalar.Keys.ElementAt(i)} {plakalar[plakalar.Keys.ElementAt(i)]}");
            }

            //.ContainsKey ile sözlük içerisinde 41 key bilgisi var mı yok mu öğreniriz
            Console.WriteLine(plakalar.ContainsKey(41));

            //.Contains ise bizden KeyValuePair bekler yani <keytipi,valuetipi>
            //41 keyi ve "Kocaeli" valuesi sözlük içinde var mı diye sorarız
            Console.WriteLine(plakalar.Contains(new KeyValuePair<int,string>(41,"Kocaeli")));

            //bir elemanı sözlükten silmek istersek .Remove kullanabiliriz sadece key bilgisini bu şekilde verebiliriz
            plakalar.Remove(34);

            //Biz burda Sözlük yapısını Generic bir şekilde tanımlamış olduk Generic olmayan bir kullanım istiyorsak bu durumda HashTable kullanabiliirz
            Hashtable ht = new Hashtable()
            {

            };

            //.Add metotu artık bizden key,value değil nesne türünde bilgi bekler
            //sonuçta object türü temel bir tür ve bu türe int string harhangi bir türde bilgi göndersekte olur
            //GenericDictionary Hastable a göre daha çok hızlı performanslı bunun sebebi box ise unboxing olaylarının yapılmıyor olması çünkü hashtable içersiine eklediğiniz bir eleman object türünde ve bu bilgiyi hashtable içerisinden aldığınızda kullandığınız türe tabiki cast etmeniz gerekiyor ya da bir bilgi attığınzıda bu attığınız bilgi de obeject türüne çevriliyor ve performans kaybı oluyor Generic türleri kullanmak daha faydalı
            ht.Add(1, "ali");
            ht.Add(2, "ahmet");
            ht.Add("3", "veli");

        }
    }
}
