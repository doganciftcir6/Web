using System;

namespace UygulamaStaticMembers
{
    //VERİTABANLARINDAKİ BAŞLIKLAR CLASSLARDAKİ PROPLARA KARŞILIK GELİYOR
    //VERİTABANLARINDAKİ HER BİR SATIRA GELEN BİLGİ İSE PRODUCT SINIFINDAN ÜRETİLECEK OLAN BİR NESNEYE KARŞILIK GELİYOR ÖRNEĞİN 5 TANE KAYIT VARSA 5 TANE NESNE OLUŞTURULACAK
    //BİZ BU VERİLERİ UYGULAMA TARAFINA NESNE OLARAK TAŞIYACAK BİR YAPI OLUŞTURUCAZ BU YAPIYADA MANAGER DİCEZ VE MANAGER SINIFI STATİC BİR SINIF OLACAK ÇÜNKÜ UYGULAMAYA GELEN HER BİR KULLANICI İÇİN AYNI MANAGER SINIFI KULLANILSIN MESLEA ALİ VELİ DİYE 2 KULLANICIMIZ VAR UYGULAMAMIZI KULLANIYOR VE BU 2 KULLANICIYA DA VERİ TABANINDAKİ AYNI KAYITLARI GÖSTERİYOR OLMAMIZ GEREKİYOR AYNI KAYITLARI ALIP 2 TANE MANAGER SINIFI TÜRETMEMİZİN BİR ANLAMI OLMAZ

    class Product
    {
        //proplarımız
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool IsApproved { get; set; }
    }
    //Sanal bir veritabanı oluşturalım yani Product nesnelerini yönetecek olan ve static olan bir yapı
    static class ProductManager
    {
        //statik bir alan dizi tanımlıcam dizinin türü Product sınıfı olacak
        //ben = dan sonra new Product diyip bilgi ataması yapabilirim ancak bunu burda yapmıcam nerde yapalım ProductManager ne zaman oluşturulursa yani kullanılırsa o zaman dizinin içini ürünlerle dolduralım dolayısıyla kanstraktıra gidicez
        //dizi tanımlarken public ya da private demedim public deseydik ProductManager. dediğimizde Products'lara ulaşabilirdik ancak bu şekilde direkt ulaşmayalım bunlara bir metot aracılığıyla ulaşalım
        static Product[] Products;

        //kanstraktır ama sınıfımız static olduğu için mutlaka static bir kanstraktır olmalı
        static ProductManager()
        {
            //5 elemanlı bir dizi olacak dedik
            Products = new Product[5];
            //Prdocuts dizisinin her bir elemanına Product sınıfından new diyip nesne üreterek içerisindeki propları doldurtucaz
            Products[0] = new Product {ProductId=1,ProductName="Iphone 5",Price=2000,IsApproved = false };
            Products[1] = new Product {ProductId=2,ProductName="Iphone 6",Price=3000,IsApproved = false };
            Products[2] = new Product {ProductId=3,ProductName="Iphone 7",Price=4000,IsApproved = true };
            Products[3] = new Product {ProductId=4,ProductName="Iphone 8",Price=5000,IsApproved = true };
            Products[4] = new Product {ProductId=5,ProductName="Iphone x",Price=6000,IsApproved = true };
            //şuanda 5 adet ürünümüz olmuş oldu   
        }
        //productslara ulaşmak için bir metot yazalım sınıf static olduğu için metotta mutlaka static olmak zorunda bu metot ürün bilgilerini geriye döndürücek
        public static Product[] GetProducts()
        {
            return Products;
        }
        //farklı metotlar oluşturabiliriz kullanıcının gönderdiği ıd ye göre liste üzerinden bir bilgi gönderen metot  o yüzden zaten geri dönüş tiğine Product diyoruz
        public static Product GetProductById(int id)
        {
            //product nesnesi oluşturalım
            Product product = null;
            foreach (var item in Products)
            {
                if(item.ProductId == id)
                {
                    product = item;
                    //break eklediğimzzde bulduğu ilk product bilgisini bize getirmesini sağlarız
                    break;
                }
            }
            return product;
        }
        //Bir metot daha yapalım girdiğimiz ürün bilgisine göre tek bir productı geriye getirsin o yüzden zaten geri dönüş tiğine Product diyoruz
        public static Product GetProductByName(string name)
        {
            //product nesnesi oluşturalım
            Product product = null;
            foreach (var item in Products)
            {
                if(item.ProductName.Contains(name.ToLower()))
                {
                    product = item;
                    //break eklediğimzzde bulduğu ilk product bilgisini bize getirmesini sağlarız içerisinde phone geçen ilk kaydı bulur ve bize getirir metotu kullanırken phone yazdığımız için containsle bunu aratıyoruz yani
                    break;
                }
            }
            return product;
        }
    }
    class UygulamaStaticMember
    {
        static void Main(string[] args)
        {
            var products = ProductManager.GetProducts();

            //artık bize gelen bir liste var listeye ulaşmak için foreach kullanabiliriz
            foreach (var item in products)
            {
                Console.WriteLine($"name: {item.ProductName} price: {item.Price}");
            }

            //girdiğimiz id ye göre çalışan metotu kullanalım
            var product2 = ProductManager.GetProductById(2);
            Console.WriteLine($"name: {product2.ProductName} price: {product2.Price}");

            //girdiğimiz name ye göre çalışan metotu kullanalım
            var product3 = ProductManager.GetProductByName("Phone");
            Console.WriteLine($"name: {product3.ProductName} price: {product3.Price}");
        }
    }
}
