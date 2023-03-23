using System;

namespace UygulamaYapiciMetotlar
{
    class Program
    {
        class Comment
        {
            //Bu içeriği Product sınıfında kullanabiliriz
            public int CommentId { get; set; }
            public string Text { get; set; }
        }
        class Prodcut
        {
            //bazı proplar oluşturalım
            //varsayılan olarak 0 değeri aktarılır int
            public int ProductId { get; set; }
            //varsayılan olarak boş değer aktarılır string
            public string Name { get; set; }
            //varsayılan olarak 0 değeri aktarılır double
            public double Fiyat { get; set; }
            //varsayılan olarak false değeri aktarılır bool
            public bool OnaylıMi { get; set; }
            //her bir ürün ile ilişkili olan birden fazla yorum olabilir dolayısıyla Comment ismindeki classı dizi olarak buraya eklicem
            public Comment[] Comments { get; set; }

            //varsayılan değerleri iptal etmek ve proplara nesne üretildiği anda değer atamak için konstraktır
            public Prodcut()
            {
                //rastgele sayı atayalım default olarak
                var rnd = new Random();
                this.ProductId = rnd.Next(11111, 99999);
                //diziyi burda set edebiliriz 3 elemean diyelim bellekte yer ayrılıyor
                this.Comments = new Comment[3];
            }
            //ancak ben bazende nesne üretme aşamasıdna bu işleri otomatikleştirmek yerine bir de aletnatif eklemek istiyorum
            //:this() ile bu 1 parametre alan konstraktır çalıştırılmadan önce  ilk konstraktır çalıştırılsın diyebiliyoruz
            public Prodcut(int productId):this()
            {
                this.ProductId = productId;
            }
            //Bir kanstraktır seçeneceği daha ekleyelim tüm değerleri dolduran
            //:this() ile bu 1 parametre alan konstraktır çalıştırılmadan önce  ilk konstraktır çalıştırılsın diyebiliyoruz ancak random değer atansın istemiyorum dolayısıyla this içerisine productId gönderirsek productId gidip bir önceki yani 2. konstraktırda set edilir
            public Prodcut(int productId, string name, double price, bool isApproved):this(productId)
            {
                
                this.Name = name;
                this.Fiyat = price;
                this.OnaylıMi = isApproved;
            }
        }
        static void Main(string[] args)
        {
            //bir tane comment oluşturalım
            var c1 = new Comment { CommentId = 1, Text = "Güzeltelefon"};

            //oluşturduğumuz Product classını kullanmak için nesne üretelim
            //var p = new Prodcut();

            //konstaktır olmadan değer doldurma böyle
            //Console.WriteLine(p.ProductId);
            //Console.WriteLine(p.Name);
            //Console.WriteLine(p.Fiyat);
            //Console.WriteLine(p.OnaylıMi);
            //konstraktır ile değer doldurmak ise
            var p = new Prodcut(123,"samsung s7",3000,true);

            var p1 = new Prodcut();
            p1.Comments[0] = c1;
            Console.WriteLine(p1.Comments[0].Text);

        }
    }
}
