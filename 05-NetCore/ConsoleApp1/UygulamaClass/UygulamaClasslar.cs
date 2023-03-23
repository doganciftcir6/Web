using System;

namespace UygulamaClass
{
    class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
    class UygulamaClasslar
    {
        static void Main(string[] args)
        {
            //Product class => name- price , description
            //Sınırsız sayıda ürün bilgisini alıp bir dizi içinde saklayınız
            //ürün adetini kullanıcı belirtin
            //Eklenen ürünler listelensin 

            Console.Write("Adet bilgisini giriniz: ");
            int adet = int.Parse(Console.ReadLine());

            Product[] products = new Product[adet];
            int i = 0;
            Product prd;
            do
            {
                prd = new Product();
                Console.WriteLine("ürün adı: ");
                prd.name = Console.ReadLine();
                Console.WriteLine("ürün fiyatı: ");
                prd.price = (int)double.Parse(Console.ReadLine());
                Console.WriteLine("ürün açıklaması: ");
                prd.description = Console.ReadLine();

                products[i] = prd;
                i++;

            } while (adet > i);
            Console.WriteLine("****************************");
            //for(int a = 0; a < products.Length; a++)
            //{
            //    Console.WriteLine($"ürün adı {products[a].name} ürün fiyat: {products[a].price} ürün açıklaması : {products[a].description}");
            //}

            //bu forun bir alternatifi var foreach products içindeki bilgileri item değişkenine tanımlar herhangi bir index numarasıyla uğraşmam gerekmiyor bu sayede
            foreach (var item in products)
            {
                Console.WriteLine($"ürün adı {item.name} ürün fiyat: {item.price} ürün açıklaması : {item.description}");
            }


    }
    }
}
