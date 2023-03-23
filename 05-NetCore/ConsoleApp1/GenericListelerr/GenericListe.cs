using System;
using System.Collections.Generic;

namespace GenericListelerr
{
    class Product
    {
        public string Name { get; set; }
    }
    class GenericListe
    {
        static void Main(string[] args)
        {
            //Generic Listeleri dinamik bir liste oluşturmak istediğimizde yani eleman sayısı belli olmayan listenin boyutunu vs başta bilmiyorsak dolayısıyla bir liste kullanmaya karar verdik bu ArrayList tanımlarsak liste içerisine farklı türde veriler atabiliyoruz ancak Generic List tanımladığımızda tipi başta belirtiyoruz ve o tipe uyan verileri anca liste içerisinde saklayabiliyoruz farkı bu

            //bir List tanımlayalım
            //liste içerisine eleman atayalım .Add ile
            //artık burdaki .Add metotu bizden int türünde bir veri bekliyor başka tip olmuyor
            List<int> sayilar = new List<int>();
            sayilar.Add(10);
            sayilar.Add(20);
            sayilar.Add(30);

            //string verileri olan bir list tamımlarkende
            List<string> isimler = new List<string>();
            //bu sefer .Add metotu bizden string bir bilgi bekler
            //ayrıca string listenin içeriisne null bir değerde atayabiliriz çünkü string tanımlaması nullable
            isimler.Add("ali");
            isimler.Add("ahmet");
            isimler.Add("yağmur");
            isimler.Add(null);

            //oluşturduğumuz Product classı üzerinden bir list tanımlamak istersek <Product> içerisine Product türünde veriler olacak diyoruz
            //eleman eklemesini direkt kanstraktır aracılığıyla da yapabiliriz
            List<Product> urunler1 = new List<Product>()
            {
                //nesne üreterek Name özelliğine değer atayabiliyoruz sonuçta class bu bilgilerine nesne üzerinden ulaşılabiliyor nesne üretmezsek bellekte bu elemanlar için yer ayıramayız
                new Product(){Name = "Samsung S6"},
                new Product(){Name = "Samsung S7"},
                new Product(){Name = "Samsung S8"},
                new Product(){Name = "Samsung S9"}
            };
            //farklı ürün tiplerini nasıl birleştiricez
            List<Product> urunler2 = new List<Product>()
            {
                //nesne üreterek Name özelliğine değer atayabiliyoruz sonuçta class bu bilgilerine nesne üzerinden ulaşılabiliyor nesne üretmezsek bellekte bu elemanlar için yer ayıramayız
                new Product(){Name = "Iphone 6"},
                new Product(){Name = "Iphone 7"},
                new Product(){Name = "Iphone 8"},
                new Product(){Name = "Iphone 9"}
            };

            //bu iki listeyi birleştirmek istersek .AddRange metotunu kullanabiliyoruz
            urunler1.AddRange(urunler2);

            //elemanlara ulaşmak istersek
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }

            foreach (var product in urunler1)
            {
                Console.WriteLine(product.Name);
            }

            //bunun yerine List içerisinden ekstra foreach metotu geliyor onuda kullanabiliriz
            //.ForEach metotu içerisine LambaExpression tanımlaması yapıyoruz
            //tüm elemanlar p içerisine aktarılıyor
            urunler1.ForEach(p => { Console.WriteLine(p.Name);});

            //elemanlara tek tek te ulaşabiliriz 0. indexteki elemana ulaşırız
            //urunler[0] dediğimizde biz nesne geliyor nesneninde .Name diyerek ilgili propa ulaşmamız gerekiyor
            Console.WriteLine(urunler2[0].Name);

            //index ile ulaşabiliyorsak tabiki for döngüsü ile de ulaşabiliriz
            for (int i = 0; i < urunler2.Count; i++)
            {
                Console.WriteLine(urunler2[i].Name);
            }

            //listenin üzerine belirli indexten başlayarak elemanları nasıl ekleriz .Insert() metotu ile 1. indexten itibaren 100 elemanını ekle deriz .Add metotu liste sonuna eleman ekliyordu farkı bu
            sayilar.Insert(1,100);
            //Insert metotu ile son elemana ekleme yapmak istiyorsak
            sayilar.Insert(sayilar.Count, 200);

            //liste içerisinde kaç tane eleman var buna da bakabiliriz .Count dediğimizde bize eleman sayısı gelir
            int count = urunler1.Count;
            Console.WriteLine(count);

            //.InserRange metotu aracılığıyla kaçıncı idexten itibaren bu bilgiyi eklicez 1. indexten itibaren urunler2 listesini ekleyelim yani listeleri birbirine atmak kopyalamak için kullanılabilir .AddRange meotu liste sonuna ekleme yapıyordu
            urunler1.InsertRange(1,urunler2);

            //liste içerisinden herhangi bir elemanı silmek .Remove metotu ile istediğimiz bir elemanı silebiliriz 10 elemanını sil dedik burda
            sayilar.Remove(10);
            //istediğniiz bir index numarasındaki elemanı silmek istiyorsak .RemoveAt metotu kullanılabilir 2. indexteki elemanı sil dedik burda
            sayilar.RemoveAt(2);
            //ya da ben eğer son elemanı silmek istiyorsam 
            sayilar.RemoveAt(sayilar.Count-1);

           

        }
    }
}
