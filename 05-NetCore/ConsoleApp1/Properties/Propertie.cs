using System;

namespace Properties
{
    class Propertie
    {
        class Product
        {
            //prop yerine bildiğimiz gibi bir değişken tanımlayalım
            //public string name;
            //private double Price;

            //BAŞKA DEĞİŞKENLER TANIMLAYALIM
            private string _name;
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        _name = value;
                    }
                    //atılmak istenen değer boşsa hata fırlatırız
                    else
                    {
                        throw new Exception("name alanı zorunlu.");
                    }
                }
            }
            private double _price;
            public double Price
            {
                // private olan _price bilgisine ulaşmak için
                get
                {
                    return _price;
                }
                // private olan _price bilgisine değer atamak için
                //atamak istediğimiz yani kullanıcının girdiği değer value olarak tanımlanır
                set
                {
                    if (value < 0)
                    {
                   this._price = 0;
                    }
                    else
                    {
                        _price = value;
                    }
                }
            }

            //PROP TANIMLAYALIM proplar bizim yerimize otomatik olarak get seti tanımlar mesela sadece okunabilir değeri değiştirilemez istiyorsak set alanını silebiliriz 
            public bool IsApproved { get; set; }


            //fiyatı private yaptık ve biz dolaylı olarak bu fiyat alanına bir bilgi atma işlemini yerine getiriyor olmamız gerekiyor bunu metotla yapabiliriz
            //public void SetPrice(double price)
            //{
            //    if(price < 0)
            //    {
            //        this.Price = 0;
            //    }
            //    else
            //    {
            //        this.Price = price;
            //    }
            //}

            //price private olduğu için cw içerisinde de p. diyip bu bilgiye ulaşamıyorum bu elemana ulaşmak içinde ayrı bir metot yazıyor olmalıyız gettır yani
            //public double GetPrice()
            //{
            //    return this.Price;
            //}


            //TÜM BUNLARIN BİR ALTERNATİFİ VAR

        }
        static void Main(string[] args)
        {
            var p = new Product();
            //değişken şeklinde tanımlama yaptığımızda p. dediğimizde değişkenlere ulaşamıyoruz çünkü tanımlamış olduğumuz değişkenler sadece class içerisinde erişilebilir oluyor dolayısıyla bu değişkenleri public olarak tanımlayalım
           // p.name = "Samsung S8";
            //fiyat alanı - değer almamalı o yüzden fiyat alanını publicten privateye çekelim ve ona değer atama yapmak için bir metot tanımlayalım
            // p.SetPrice(2000);
            //price private olduğu için cw içerisinde de p. diyip bu bilgiye ulaşamıyorum bu elemana ulaşmak içinde ayrı bir metot yazıyor olmalıyız
            // Console.WriteLine(p.GetPrice());

            //Alternatif olarak get set lerimiz var
            //- değer girersek bu durumda _price a 0 atanır
            //set metotu
            p.Price = -2000;
            //get metotu
            Console.WriteLine(p.Price);

            //boş bir değer atarsak hata verecektir
            //set metotu
            p.Name = "";
            //get metotu
            Console.WriteLine(p.Name);
        }
    }
}
