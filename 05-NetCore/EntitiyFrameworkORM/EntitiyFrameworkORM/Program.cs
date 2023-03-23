using EntitiyFrameworkORM.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EntitiyFrameworkORM
{
    class Program
    {
        //Bir Context sınıfı oluşturalım ki databaseyi oluşturmak için context sınıfı ekleyip burdaki entitiyleri context ile ilişkilendirmemiz gerekiyor ve daha sonra magration denilen bir özellik ile databasenin bu yapıya göre oluşturulmasını sağlıcaz
        //yaptığımız her değişiklik için yeni bir magration oluşturmalıyız
        //Context sınıfı
        //ShopContext bizim adımıza veritabanı bağlantısını kendi yapacak ancak buna tabiki hangi database ile çalışacağını hangi provaytır driver ile çalışacağını tanımlamamız gerekiyor
        public class ShopContext : DbContext
        {
            //şimdi kullanmak istediğimiz entityleri buraya ekliyor olmamız gerekiyor bunlarıda dbSet olarak çoğul isim ile property olarak eklicez
            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Address> Addresses { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Supplier> Suppliers { get; set; }
            //Products , Products, Orders adında 3 adet listemiz var
            //Bizim yazdığımız linq kodun sql diline çevrilince doğru olup olmadığını kontrol etmek için bunları yazıcaz
            public static readonly ILoggerFactory MyLoggerFactory
                    = LoggerFactory.Create(builder => { builder.AddConsole(); });
            //ShopContext bizim adımıza veritabanı bağlantısını kendi yapacak ancak buna tabiki hangi database ile çalışacağını hangi provaytır driver ile çalışacağını tanımlamamız gerekiyor dolayısıyla Context oluştuğunda çalıştırılacak olan bir metotumuz var metotumuzun ismi OnConfiguring metotu
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //sqlLite kullandığımız için optionsBuilder. dediğimizde UseSqlite'ı seçtik ve codefirst yaptığımız için Data Source'yi kendimiz isimlendirdik shop.db diye 
                //sqlLite bir server olmadığı için kullanıcı adı parola gibi bilgileri burada yazmamız gerekmiyor
                optionsBuilder
                    //Bizim yazdığımız linq kodun sql diline çevrilince doğru olup olmadığını kontrol etmek için bunları yazıcaz
                    .UseLoggerFactory(MyLoggerFactory)
                  //.UseSQllite bundan bağımsız bir şey
                  // .UseSqlite("Data Source=shop.db");
                  //SQLSERVER BAĞLAYALIM () içine server name bilgisini girelim
                  //ShopDb olmadığı için codefirst olup yeni database oluşturur
                  //SSPI ise şuanda yerel bir server kullanmamız ve kullanıcı ve parola şuanda vermiyoruz
                  // .UseSqlServer(@"Data Source= DESKTOP-4UF23CE;Initial Catalog=ShopDb;Integrated Security=SSPI;");
                  //MYSQL BAĞLANTISI YAPALIM
                  .UseMySql(@"server=localhost;port=3306;database=ShopDb;user=root;password=mysql1234;");
            }

            ////fluent api için bu metot kullanılır
            //çoka çok ilişki için
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //bu tabloyu databsede tablo olarak kullanmak istiyoruz fakat database'de bu tablo ProductCategory olarak anıılmasın'da farklı isimle anılması için ilgili entity üstüne[Table("UrunKategorileri")] diyebiliriz bunun fluentapideki karşılığı context içerisinde
                //modelBuilder.Entity<Product>().ToTable("Urunler");

                //string kolon ismini zorunlu kılan required'ın fluentapideki karşılığı context içerisinde maksimum 11 karakter ve zorunlu bir alan demiş oluruz
                // modelBuilder.Entity<Customer>().Property(p => p.IdentityNumber).HasMaxLength(11).IsRequired();

                //index bırakma işlemi user tablosunun username alanı için 
                //modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

                //modelBuilder.Entity diyince entity'e konumlanmış oluyoruz
                //.HasKey ile bu entity'in bir anahtarı olmasını sağladık ve bu anahtarı ise 2 tane id'nin kombinasyonu olarak tanımladık bu tablanun 2 tane birincil anahtarı olacak dedik yani bu sayede tekrarlayan kayıtlar database tarafından kabul edilmez
                modelBuilder.Entity<ProductCategory>().HasKey(t => new { t.ProductId, t.CategoryId });
                //çoka çok ilişkiyi tanımlamak için
                //.HasOne() ile Product entity'si bizim için tek bir tane olacak diyoruz
                //.WithMany ile birden fazla productCategorisi var
                //.productcategoriesinde productId si bizim için yabancaı anahtar diyoruz .HasForeignKey ile
                modelBuilder.Entity<ProductCategory>().HasOne(pc => pc.Product).WithMany(p => p.ProductCategories).HasForeignKey(pc => pc.ProductId);
                //aynı işlemi category tablosu içinde yapmamız lazım
                modelBuilder.Entity<ProductCategory>().HasOne(pc => pc.Category).WithMany(c => c.ProductCategories).HasForeignKey(pc => pc.CategoryId);
            }
        }

        //Tablolar arası ilişki tipleri
        //One to Many
        //One to One
        //Many to Many

        //convetion biz karışmadan sistemin ıd yi primarykey olarak algılamasına deniyor mesela
        //data annotations propların üstüne özellik ekleyip maxlenght gibi değişikliklere deniyor ikinci en baskın budur
        //fluent api en baskını bu hepsini ezebilir context içerisinde yazdığımız entity'e konumlanma olayı 

        //Entity Sınıfları
        //Entity oluşturmamızdaki sebep
        //(uygulama tarafı)Product(Id,Name,Price) => (database tarafı)Product(Id,Name,Price)
        //yani bu sayede ben database tarafıyla uğraşmıcam uygulama tarafında oluşturmuş olduğum classlar magration denilen bir yöntemle database tarafındaki tablolara dönüştürülecek

        //user tablosu
        //eklediğimiz her kullanıcının birden fazla adresi olabilir dolayısıyla address tablosuna bir yabancı anahtar ekleriz
        public class User
        {
            public int Id { get; set; }
            //
            public string Username { get; set; }
            //Column özelliğinde database tarafında oluşturulacak olan veri tipini tanımlayabiliyoruz ilgili prop üzerinde [TypeName="varchar(20)"] gibi
            public string Email { get; set; }
            //eklediğimiz her kullanıcının birden fazla adresi olabilir dolayısıyla bir class tablo daha eklicem Address tablosu
            //birden fazla adres olacağı için bir list
            //dolayısıyla ben artık elde ettiğim herhangi bir user üzerinden  Adresses dediğim zaman bana o kullanıcıya ait olan adres bilgileri gelecek
            public List<Address> Adresses { get; set; }  //navigation property
            //BİREBİR İLİŞKİ bunu list değilde tek bir obje olarak tanımlarsam birebir ilişki kurmuş oluruz
            public Customer Customer { get; set; }
            //dolayısıyla ben artık elde ettiğim herhangi bir user üzerinden  Customer dediğim zaman bana o kullanıcıya ait olan Customer bilgileri gelecek
        }
        //gelen kullanıcı customer'mı yoksa supplier'mı bunun bilgisini tutmak isteyebiiliriz
        //User tablosu ile Customer tablosu arasında bire-bir ilişki kurucaz
        //user tablosunda olan bir kaydı mutlaka user tablosuna eklememiz gerekiyor ve bu kayıdın da ilişkili olan yabancı anahtar diğer tabloda sadece 1 kere tekrarlanması gerekiyor bu durumda birebir ilişkiden söz edebiliriz
        public class Customer
        {
            public int Id { get; set; }
            public string IdentityNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            //Fullname'i sadece uygulama tarafında kullanmak istiyorum databasede olmayacak bu yüzden [NotMapped] ekleyebiliriz ilgili prop üstüne ya da herhangi bir kolon ismini değiştirmek istiyorsam ilgili prop üstüne [Column("customer_id")] böyle bir kullanım yapabiliriz
            [NotMapped]
            public string FullName { get; set; }
            //bire-bir ilişki için
            public User User { get; set; }
            //yabancıl anahtar customer tablosuna eklenir çünkü bir user kaydını önce database'e eklemek gerekiyor ve bu user'ın id bilgisini almamız gerekyior ve bu id bilgisiyle gelip bir customer kaydı oluşturucaksın ancak oluşturulan userıd bilgisini buraya eklemen lazım yani mantık bir tane base tablomuz var ve temel tabloya ait olan kayıtları ıd bilgilerini alarak ilgili customer tablosuna sadece 1 kayıt ekliyoruz ve temel tablonun ıd bilgisi customer tablosunun yabancı anahtarı olarak işaretlenecek ancak burası unic tek bir kayıda karşılık gelecek
            public int UserId { get; set; }
        }
        //suppllier tablosu
        public class Supplier
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TaxNumber { get; set; }
        }
        //Address tablosu user tablosu ile adress tablosu arasında bire-çok ilişkisi vars

        public class Address
        {
            //burada entity içlerindeki ıd alanları otomatik olarak 0 dan başlayıp artıyorlar Identity özellikleri oluyor yani bunu istemediğimiz zamanlar olabilir bunun için iligili prop üzerine gelip [DatabaseGenerated(DatabaseGeneratedOption.None)] diyebiliyoruz ve burda adres oluşturmak için ıd kolonuna mutlaka bir değer göndermemiz gerekir bunu diğer sayısal proplarda da kullanabiliyoruz
            public int Id { get; set; }
            public string Fullname { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            //ıd bilgisinden başka bide o ıdyi işaret eden user objesine de ulaşmak istiyorum dolayısıyla bir user objesi oluşturalım
            public User User { get; set; }  //navigation property
            //eklediğimiz her kullanıcının birden fazla adresi olabilir dolayısıyla address tablosuna bir yabancı anahtar ekleriz UserId
            //? ile nullable olarak işaretleyim dolayısıyla ıd bilgisi girilmediğinde null değer gelir ayrıca bir yabancı anahtar olduğu için mutlaka user tablosundan bir ıd değerini kullanmamız gerekiyor
            //mutlaka addresin bir user'a ait olması gerektiği için ? yapmam notnull bir alan oluşmuş olur
            public int UserId { get; set; }
        }


        //product tablosu
        public class Product
        {
            //eklediğimiz Id bizim için bir primary key olacak
            //primary key (Id,<type_name>Id)
            //dğer Id ismine burada ProductId veya Id den başka bir kullanım yaparsak UrunId gibi mesela bunu entity anlayamıyor primary key olduğunu anlamıyor o yüzden başına [Key] yazarak primary key olduğunu belirtmeliyiz
            public int ProductId { get; set; }
            //bir varchar alanı oluşturucak string ile ve varchar(Max) olarak tanımlanacak karakter sınırlaması yapmadığımız için
            //karakter sınırlaması yapmak istersek prop üstüne [MaxLenght(100)] şeklinde yazabiliyoruz
            //peki Name alanı zorunlu bir alan olacak mı eğer zorunlu bir alan olamsını istiyorsak üstüne [Required] ekleyebiliriz
            //string varsayılan olarak nullable olduğu için dolayısıyla zorunlu olması içni [Required] ekliyoruz
            [MaxLength(100)]
            [Required]
            public string Name { get; set; }
            //decimal bir alan zaten zorunlu bir alandır yani nullable bir değer değildir tanımlanmadığı zaman null değil 0 değeri otomatik tanımlanır eğer decimalin sonuna ? eklersem optional bir alana çeviririm yani yani fiyat alanı nullable olarak işaretlenmiş olur
            public decimal Price { get; set; }
            //veritabanında bir değişiklik yapmak istesek örneğin mesela bu tabloya bir kolon daha eklediğimizi düşünelim bu değişikliğin veritabanına aktarılması için birinci yol magrationu siliğ tekrardan oluşturmak ancak bunu yapınca elimizdeki var olan şema gitmiş olur dolayısıyla biz bu değişikliğin olduğunu durak noktalarıyla belirtiyor olmamız gerekiyor yani  bir başlangıç magrationum var tamam sonra değişikliği yaptım bunun için bir durak noktası ikinci bir magrationa ihtiyacım varki daha önceki data yapısı bozulmasın eğer bir önceki durak noktasına dönmek istiyorsak update-database durak adı yazarak önceki durağa dönebiliyoruz remove-migration ile son eklediğimiz migrationu silebiliyoruz ayrıca ve update-database 0 dediğimizde 0. adıma gelmiş oluruz ve tüm migrationları silmek için migration klasörünü silebiliriz, drop-database dersek server uzerinden database'yi tamamen silmiş oluruz
            //burda bire çok ilişki vardı
            // public int CategoryId { get; set; }
            //çoka çok ilişki
            //çoka çok ilişki için
            public List<ProductCategory> ProductCategories { get; set; }

        }

        //çoka çok ilişki için yeni bir entity gerekiyor
        //ancak bazen uygulama içersinde kullanmış olduğumuz bir objeyi bir sınıfı gidip database tablosu olarak kullanmak istemeyebiliriz bu durumda ilgili entity'in üzerine [NotMapped] eklenir ya da bu tabloyu databsede tablo olarak kullanmak istiyoruz fakat database'de bu tablo ProductCategory olarak anıılmasın'da farklı isimle anılması için ilgili entity üstüne [Table("UrunKategorileri")] diyebiliriz bunun fluentapideki karşılığı context içerisinde
        public class ProductCategory
        {
            //2 yabancı anahtar burda birleştirilecek
            public int ProductId { get; set; }
            //navigation property'sinnide burda olması lazım
            public Product Product { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
        }

        //Category tablosu
        //procut kaydının birden fazla kategorisi olursa ya da bir categronin birden fazla product'ı olabilir dolayısıyla çoka-çok ilişki kurulur
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            //çoka çok ilişki için
            public List<ProductCategory> ProductCategories { get; set; }
        }

        //bir entity daha oluşturalım bu yeni oluşturulan entity'i önce Context içerisine tanımlıyoruz daha sonra bu değişiklik için bir migration durak noktası oluşturuyoruz ve değişiklerin database'ye gitmesi için update database yapıyoruz eğer bir önceki durak noktasına dönmek istiyorsak update-database durak adı yazarak önceki durağa dönebiliyoruz remove-migration ile son eklediğimiz migrationu silebiliyoruz ayrıca ve update-database 0 dediğimizde 0. adıma gelmiş oluruz ve tüm migrationları silmek için migration klasörünü silebiliriz, drop-database dersek server uzerinden database'yi tamamen silmiş oluruz
        public class Order
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public DateTime DateAdded { get; set; }
        }

        

        //veri taşımak için class çoklu tablo çalışma olayı
        public class CustomerDemo
        {
            public CustomerDemo()
            {
                Orders = new List<OrderDemo>();
            }
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public int OrderCount { get; set; }
            //OrderDemo'yu CustomerDemo ile ilişkilendiriyor olmalıyız
            //Bir müşterinin birden fazla order'ı olabilir dolayısıyla list
            //yani her bir customer'ın birden fazla order bilgisi olacak
            public List<OrderDemo> Orders { get; set; }
        }
        //veri taşımak için class çoklu tablo çalışma olayı
        public class OrderDemo
        {
            public int OrderId { get; set; }
            public decimal Total { get; set; }
            //ProductDemo'yu ilişkilendirelim
            public List<ProductDemo> Products { get; set; }
        }
        //veri taşımak için class çoklu tablo çalışma olayı
        public class ProductDemo
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
        }

        //test verilerinin otomatik eklenmesi data seeding için bir static class oluşturucam bunu yaptıktan sorna artık benim içni databse silinmiş mi silinmemiş mi önemli değil eğer databasede bir bilgi yoksa boş olan tabloların hepsi otomatik doldurulur
        public static class DataSeeding
        {
            //static bir metot
            public static void Seed(DbContext context)
            {
                if (context.Database.GetPendingMigrations().Count() == 0)
                {
                    //eğer bekleyen bir migration yoksa bütün migration'lar database'e aktarılmışsa 
                    //bu durumda test verilerini database'e ekleyelim
                    //bana gelecek contexti karşılayayım
                    //ShopContext

                    //AbcContext
                    if (context is ShopContext)
                    {
                        ShopContext _context = context as ShopContext;

                        if (_context.Products.Count() == 0)
                        {
                            //eğer product yoksa
                            //product ekle
                            _context.Products.AddRange(Products);
                        }
                        if(_context.Categories.Count() == 0)
                        {
                            //eğer category yoksa
                            //category ekle
                            _context.Categories.AddRange(Categories);
                        }
                    }
                    context.SaveChanges();
                    
                }
            }
            //özellikler oluşturalım bize bir liste getirsin
            private static Product[] Products =
            {
                new Product(){Name="Samsung S6",Price=2000},
                new Product(){Name="Samsung S7",Price=3000},
                new Product(){Name="Samsung S8",Price=4000},
                new Product(){Name="Samsung S9",Price=5000},
            };
            private static Category[] Categories =
            {
                new Category(){Name="Telefon"},
                new Category(){Name="Elektronik"},
                new Category(){Name="Bilgisayar"},
            };

        }

        static void Main(string[] args)
        {
            //ekleme metotlarını çağıralım
            //AddProducts();
            //bütün ürünleri gösteren metotu çağıralım
            //GetAllProducts();
            //girdiğimiz id ye göre bilgi getiren metotu çağıralım
            //GetProductById(2);
            //girdiğimiz name ye göre bilgi getiren metotu çağıralım
            //GetProductByName("samsung");
            //VeriTabanında kayıt güncelleme için metotu çağıralım
            // UpdateProduct();
            //VeriTabanından kayıt silmek için metot çağıralım
            //DeleteProduct(1);

            //sql servera geçtikten sonra bilgi eklemesi yapalım provider değişimi yapınca hiç bir şey değiştirmiyoruz sadece EntityFrameworkCore kuruyoruz ve bağlantısını yapıyoruz Context içinde ve migrationu da silip yeniden yüklemek gerek
            //AddProducts();

            //mySqle geçtikten sonra bilgi eklemesi yapalım provider değişimi yapınca hiç bir şey değiştirmiyoruz sadece EntityFrameworkCore kuruyoruz ve bağlantısını yapıyoruz Context içinde ve migrationu da silip yeniden yüklemek gerek
            // AddProducts();

            //OnetoMany için bir metot user bilgisi oluşturan metotu çağıralım
            // InsertUser();
            //address bilgilerini oluşturan metotu'Da çağıralım
            //InsertAddresses();
            //NAVİGATİON PROPERTYLERİ KULLANARAK BİLGİ EKLEME İŞLEMİNİ NASIL YAPICAZ
            //bu sayede herhangi bir ıd bilgisi göndermeden direkt user bilgilerini direkt ilgili user objesiyle ilişkilendirmiş oluyoruz
            //using (var db = new ShopContext())
            //{
            //    //user bilgisini alıcam cinarturan isimli kullanıcıyı burada alıcam
            //    var user = db.Users.FirstOrDefault(i => i.Username == "cinarturan");
            //    //Bir kontrol yapıcam bu bilgi databasede var mı diye
            //    if (user != null)
            //    {
            //        user.Adresses = new List<Address>();
            //        //bu durudma bilgi vardur user null'a eşit değil
            //        user.Adresses.AddRange(
            //            new List<Address>()
            //            {
            //            new Address() { Fullname = "Çınar Turan", Title = "İş adresi 1", Body = "Kocaeli" },
            //            new Address() { Fullname = "Çınar Turan", Title = "İş adresi 2", Body = "Kocaeli" },
            //            new Address() { Fullname = "Çınar Turan", Title = "İş adresi 3", Body = "Kocaeli", UserId = 2 },
            //            }
            //            );
            //        db.SaveChanges();
            //    }
            //}

            //OnetoOne
            //kayıt ekelmesi yapalım
            //1 numaralı user bilgisiyle bir customer database'ye eklenecek ve 1 numaralı userId databasede zaten olduğu için problem çıkmayacak
            //userId customer tablosunda unic olduğu için aynı userId yi tekrar kullanamam
            //using (var db = new ShopContext())
            //{
            //    //bir customer oluşturalım
            //    var customer = new Customer()
            //    {
            //        IdentityNumber = "123455654",
            //        FirstName = "Sadık",
            //        LastName="Turan",
            //        //burda databasede olan bir user bilgisini seçebilirim navigation property olduğu için
            //        User = db.Users.FirstOrDefault(i=>i.Id==3) //customer içerisinde navigation property tanımlamıştık ondan bunu yapabildik
            //    };
            //    db.Customers.Add(customer);
            //    db.SaveChanges();

            //}
            //peki ben bir user bilgisini eklerken aynı zamanda customer bilgisinide eklemek istersem yani var olan bir kayıt değilde yeni bir kayıt
            //using (var db = new ShopContext()) {
            //    //Bir user oluşturalım
            //    var user = new User()
            //    {
            //        Username = "deneme",
            //        Email = "deneme@gmail.com",
            //        Customer = new Customer()
            //        {
            //            FirstName = "Deneme",
            //            LastName = "Deneme",
            //            IdentityNumber = "12334"
            //        }
            //    };
            //    db.Users.Add(user);
            //    db.SaveChanges();
            //}

            //çoka çok ilişki için bilgi ekleyelim
            //using (var db = new ShopContext())
            //{
            //    var products = new List<Product>()
            //    {
            //       new Product(){Name="Samsung S5",Price=2000},
            //       new Product(){Name="Samsung S6",Price=3000},
            //       new Product(){Name="Samsung S7",Price=4000},
            //       new Product(){Name="Samsung S8",Price=5000},
            //    };
            // //  db.Products.AddRange(products);
            //    var categories = new List<Category>()
            //    {
            //        new Category(){Name="Telefon"},
            //        new Category(){Name="Elektronik"},
            //        new Category(){Name="Bilgisayar"}
            //    };
            //    // db.Categories.AddRange(categories);
            //    //product ve category tablololarına kayıt eklemesi yaptık önce
            //    int[] ids = new int[2] { 1, 2 };
            //    //1 numaralı ürünü almış olalım
            //    var p = db.Products.Find(1);

            //    p.ProductCategories = ids.Select(cid => new ProductCategory() {
            //        CategoryId = cid,
            //        ProductId = p.ProductId
            //    }).ToList();




            //    db.SaveChanges();



            //}


            //test verilerinin otomatik eklenmesi data seeding için bir static class çağıralım
            // DataSeeding.Seed(new ShopContext());
            //*****************************************************************************************
            //DATABASE FİRST BAĞLANTISINDAN SONRA
            //using (var db = new northwindContext())
            //{
                //TEK TABLO İLE ÇALIŞMA

                ////Prdoucts tablosundaki bilgileri liste şeklide alalım
                //var products = db.Products.ToList();
                ////ve pRODUCT tablosundaki name kolonundaki bilgileri gezelim
                //foreach (var item in products)
                //{
                //    Console.WriteLine(item.ProductName);
                //}

                //ALIŞTIRMALAR
                //Tüm müşteri kayıtlarını getriniz
                //var customers = db.Customers.ToList();
                //foreach (var item in customers)
                //{
                //    Console.WriteLine(item.FirstName +" "+item.LastName);
                //}

                //Tüm müşteri kayıtlarının sadece first_name ve last_name bilgilerini getiriniz
                //var customers = db.Customers.Select(c => new { c.FirstName, c.LastName });
                //foreach (var item in customers)
                //{
                //    Console.WriteLine(item.FirstName + " " + item.LastName);
                //}

                //New York'da yaşayan müşterileri isim sırasına göre getiriniz
                //.select .where den sonra yazılır
                //var customers = db.Customers.Where(i => i.City == "New York").Select(s=> new { s.FirstName, s.LastName}).ToList();
                //foreach (var item in customers)
                //{
                //    Console.WriteLine(item.FirstName + " " + item.LastName);
                //}

                //"Beverages" kateogirisne ait ürünlerin isimlerini getiriniz.
                //var productnames = db.Products.Where(i => i.Category == "Beverages").Select(i=> i.ProductName).ToList();
                //foreach (var name in productnames)
                //{
                //    Console.WriteLine(name);
                //}

                //En son eklenen 5 ürün bilgisini alınız.
                //var products = db.Products.OrderByDescending(i=> i.Id).Take(5);
                //foreach (var p in products)
                //{
                //    Console.WriteLine(p.ProductName);
                //}

                //Fiyatı 10 ile 30 arasında olan ürünlerin isim,fiyat bilgilerini alınız
                //var products = db.Products.Where(i => i.ListPrice >= 10 && i.ListPrice <= 30).Select(i => new { i.ProductName, i.ListPrice }).ToList();
                //foreach (var item in products)
                //{
                //    Console.WriteLine(item.ProductName + " " + item.ListPrice);
                //}

                //"Beverages" kategorisindeki ürünlerin ortalama fiyatı nedir?
                //var ortalama = db.Products.Where(i => i.Category == "Beverages").Average(i => i.ListPrice);
                //Console.WriteLine("ortalama: {0}",ortalama);

                //"Beverages" kategorisinde kaç ürün vardır?
                //var adet = db.Products.Count(i => i.Category == "Beverages");
                //Console.WriteLine("adet: {0}", adet);

                //"Beverages" veya "Condiments" kategorilerindeki ürünlerin toplam fiyatı nedir
                //var toplam = db.Products.Where(i=>i.Category == "Beverages" || i.Category == "Condiments") .Sum(i => i.ListPrice);
                //Console.WriteLine("toplam: {0}",toplam);

                //'Tea' kelimesini içeren ürünleri getiriniz.
                //var products = db.Products.Where(i => i.ProductName.ToLower().Contains("Tea".ToLower()) || i.Description.ToLower().Contains("Tea".ToLower())).ToList();
                //foreach (var item in products)
                //{
                //    Console.WriteLine(item.ProductName);
                //}

                //En pahalı ürün ve en ucuz ürün hangisidir?
                //var minPrice = db.Products.Min(i => i.ListPrice);
                //var maxPrice = db.Products.Max(i => i.ListPrice);
                //Console.WriteLine("min: {0} max: {1}",minPrice,maxPrice);

                //var minproduct = db.Products.Where(i => i.ListPrice == (db.Products.Min(a => a.ListPrice))).FirstOrDefault();
                //Console.WriteLine($"name: {minproduct.ProductName} price: {minproduct.ListPrice}");

                //var maxproduct = db.Products.Where(i => i.ListPrice == (db.Products.Max(a => a.ListPrice))).FirstOrDefault();
                //Console.WriteLine($"name: {maxproduct.ProductName} price: {maxproduct.ListPrice}");

                //ÇOK TABLO İLE ÇALIŞMA
                //burada i.dediğimizde customerlara ulaşabiliyoruz ayrıca orderlara da ulaşabiliyoruz çünkü navigtaion propertyimiz var customers tablosunda
                //var customers = db.Customers.Where(i => i.Orders.Any()).Select(i=> new CustomerDemo{ Name = i.FirstName, CustomerId = i.Id, OrderCount=i.Orders.Count(), Orders = i.Orders.Select(a=>new OrderDemo {OrderId=a.Id,Total=(decimal)a.OrderDetails.Sum(od=> od.Quantity * od.UnitPrice),Products = a.OrderDetails.Select(p=>new ProductDemo {ProductId = (int)p.ProductId, Name = p.Product.ProductName }).ToList() }).ToList() }).OrderBy(i=>i.OrderCount).ToList();
                //foreach (var customer in customers)
                //{
                //    Console.WriteLine($" id: {customer.CustomerId} name : {customer.Name} count: {customer.OrderCount}");
                //    foreach (var order in customer.Orders)
                //    {
                //        Console.WriteLine($"order id: {order.OrderId} total: {order.Total}");
                //        foreach (var product in order.Products)
                //        {
                //            Console.WriteLine($"product id: {product.ProductId} name: {product.Name}");
                //        }
                //    }
                //}

                //******************************************************************
                //klasik sql sorguları yazmak
                //var city = "Miami";
                //var customers = db.Customers.FromSqlRaw("select *from customers where city = {0}",city).ToList();
                //foreach (var item in customers)
                //{
                //    Console.WriteLine(item.FirstName);
                //}
                //}

                using (var db = new CustomNorthwindContext())
                {
                var customers = db.CustomerOrders.FromSqlRaw("select c.id as CustomerId,c.first_name as FirstName,count(*) as OrderCount from customers c inner join orders o on c.id=o.customer_id group by c.id").ToList();
                foreach (var item in customers)
                {
                    Console.WriteLine("order id : {0} firstname: {1} order count: {2}",item.CustomerId,item.FirstName,item.OrderCount);
                }
                }


        }

        //OnetoMany için bir metot user bilgisi oluşturan
        static void InsertUser()
        {
            var users = new List<User>()
            {
                new User(){Username="sadikturan",Email="info@sadikturan.com"},
                new User(){Username="cinarturan",Email="info@cinarturan.com"},
                new User(){Username="yigitbilgi",Email="info@yigitbilgi.com"},
                new User(){Username="adabilgi",Email="info@adabilgi.com"},
            };
            //Bilgileri yazdık bir context oluşturalım
            using (var db = new ShopContext())
            {
                //bilgileri Users tablosuna ekleyelim
                db.Users.AddRange(users);
                //değişiklikleri kaydedelim
                db.SaveChanges();
            }
        }
        //ilgili userlar'la ilişkilendirilmiş olan adress bilgilerini ekleyecek metot oluşturalım
        static void InsertAddresses()
        {
            var address = new List<Address>()
            {
                new Address(){Fullname = "Sadık Turan", Title="Ev adresi", Body="Kocaeli",UserId=1},
                new Address(){Fullname = "Sadık Turan", Title="İş adresi", Body="Kocaeli",UserId=1},
                new Address(){Fullname = "Yiğit Bilgi", Title="Ev adresi", Body="Kocaeli",UserId=3},
                new Address(){Fullname = "Yiğit Bilgi", Title="İş adresi", Body="Kocaeli",UserId=3},
                new Address(){Fullname = "Çınar Turan", Title="İş adresi", Body="Kocaeli",UserId=2},
                new Address(){Fullname = "Ada Bilgi", Title="İş adresi", Body="Kocaeli",UserId=4},
            };
            //Bilgileri yazdık bir context oluşturalım
            using (var db = new ShopContext())
            {
                //bilgileri Addresses tablosuna ekleyelim
                db.Addresses.AddRange(address);
                //değişiklikleri kaydedelim
                db.SaveChanges();
            }
        }


        //********************************************************************************************
        //VeriTabanından kayıt silmek için metot
        //silmek istediğimiz kayıdın dışarıdan id şelinde alalım o id'li kayıt silnisin
        static void DeleteProduct(int id)
        {
            //SİLME İŞLEMİNİ BU SEFER SELECT İŞLEMİ YAPMADAN YAPALIM
            //Context'ten bir nesne üretelim
            using (var db = new ShopContext())
            {
                //productId si 6 olan bilgiyi bu şekilde işaretlicem
                var p = new Product() { ProductId = 6 };
                //ve silme işlemini yapıcam
                db.Products.Remove(p);
                db.SaveChanges();

            }

            //Context'ten bir nesne üretelim
            //using (var db = new ShopContext())
            //{
            //    //silmek istediğimiz ürünü almamız gerekiyor başta
            //    var p = db.Products.FirstOrDefault(i => i.ProductId == id);
            //    //konrtolünü yapıyor olmalıyız bu bilgi databasede var mı diye
            //    if (p != null)
            //    {
            //        //p objesi null değilse bu durumda bilgi vardır silme işlemini yaparız
            //        //.Remove metotu bizden bir entity bekliyor
            //        db.Products.Remove(p);
            //        //yaptığımız değişiklikleri veritabanına kayıt edelim
            //        db.SaveChanges();
            //        Console.WriteLine("veri başarıyla silindi.");
            //    }
            //}
        }

        //VeriTabanında kayıt güncelleme için metot
        static void UpdateProduct()
        {
            //GÜNCELLEME YAPMAK İÇİN AŞAĞIDAKİ 2YÖNTEM DEĞİLDE HAZIR OLARAK GELEN UPDATE METOTUNU DA KULLANABİLİRİZ
            //Context'ten bir nesne oluşturulaım
            using (var db = new ShopContext())
            {
                //Bir obje alalım id'si 1 olan bilgiyi
                var p = db.Products.Where(i => i.ProductId == 1).FirstOrDefault();
                //bu bilgi gerçekten var mı yok mu bunun kontrolünü yapıcaz
                if (p != null)
                {
                    //bu durumda bilg igelmiştir p null'a eşit değilse çünkü
                    //Bilgi geldiyse update yapabiliriz
                    //tek bir product objesini .Update metotu ile update edebiliriz ya da bir listeyi .UpdateRange metotu ile update edebiliriz
                    p.Price = 2400;
                    //bu.Update() e bütün objeyi gönderdiğimiz için tüm alanlar güncellenir aslında sadece Price değil
                    db.Products.Update(p);
                    //değişiklerin veritabanına kaydedilmesi için
                    db.SaveChanges();
                }
            }


            //GÜNCELLEME YAPMAK İÇİN AŞAĞIDAKİ GİBİ İLLA BİR SELECT ÇALIŞTIRMAM GEREKMİYOR
            //Context'ten bir nesne üretelim
            //using (var db = new ShopContext())
            //{
            //    //güncellemek istediğimiz elemanı bir entitiy olarak tanımlamamız  gerekiyor
            //    //select sorgusu olmadan bilgiyi alabiliriz ıd'si 1 olan kayıt
            //    var entity = new Product() { ProductId = 1 };
            //    //.Attach() metotu ile biz bu entity i liste üzerine ekliyoruz yani bu durumda aslında ChangeTracking'i iligi entity için aktif etmiş oluyoruz
            //    //.ATttach() metotu verilen entity için bir tracking yani bir takibi burda başlatıyor
            //    db.Products.Attach(entity);
            //    //dolayısıyla fiyat alanında bir güncelleme yapalım
            //    entity.Price = 3000;
            //    //ve değişiklikleri kaydedelim
            //    db.SaveChanges();

            //}


            //Context ten bir nesne oluşturalım
            //   using (var db = new ShopContext())
            // {
            //ilk önce güncelleyecek olduğumuz bir entity i alıyor olmalıyız
            //bir koşula göre bir bilgi alalım
            //change tracking default olarak yapılıyor değişikliklerin takibi olayı aktif ediliyor güncelleme olması için takip edilme olayının gerçekleiyor olması lazım .AsNoTracking() eklersek buraya takip olayını kapatmış oluruz ve güncelleme yapılmaz bunu ne zaman kullanmamız lazım biz veritabanından bir obje bir kayıt aldığımızda ve bu kayıtlar üzerinde herhangi bir güncellemeye yapmayacaksak .AsNoTracking() kullanırız
            //   var p = db.Products.Where(i => i.ProductId == 1).FirstOrDefault();
            //.FirstOrDefault() ile tek bir kayıt gelsin diyelim ve kayıt gelmiyorsa bize null değer gelir bu sayede
            //bu kayıt var mı yok mu bunun kontrolünü yapalım
            //  if (p != null)
            //  {
            //null'a eşit değilse demek ki kayıt bize gelmiştir dolayısıyla biz p objesinin istediğimiz bir değerini güncelleyebiliriz
            //  p.Price *= 1.2m;  //YÜZDE 20 ZAM YAPMIŞ OLALIM fiyat decimal olduğu için m ekleyelim sonuna ve decimal sayıyla çarpılmasını sağlayalım
            //change tracking kavramıyla alınan objenin takibi yapılır ve obje üzerinde herhangi bir değişiklik olduktan sonra gelip eğer context üzerinden yani db.SaveChanges() çağırırsak ilgili tutulan değişiklikler databasede'de yapılır update yapılıyor yani
            //db.SaveChanges();
            //Console.WriteLine("Güncelleme yapıldı.");
        }
    


        //Veri Tabanından Kayıt Seçme için 
        //girilen name bilgisine göre kayıt getiren bir metot yapalım ve ayrıca fiyatıı 1000 den büyük olan ürünler gelsin 
        static void GetProductByName(string name)
        {
            //Context nesenesini oluşturalım
            using (var context = new ShopContext())
            {
                //context.Products bunu dediğimizde Products listesinin bir referansını almış oluruz
                var result = context.Products.Where(p => p.Name.ToLower().Contains(name.ToLower())).Select(p => new { p.Name, p.Price }).ToList();
                //bu referans üzerinden belli kriterler belli sorgulama kriterleri ekleyebiliiriz mesela tüm bilgileri değilde fiyatı 1000 den yüksek olanları getir gibi belli filrteler ekleyip en sonda bu sorguyu çalıştırmamız gerekiyor bu sorguyu en son databaseye göndermek için .SaveChanges() diyorduk ya aynı işi yapan burda da .ToList() eklemeliyiz
                //sonuç benim için bir liste olmasın sadece tek bir prodct objesi olsun istiyorsam .First() kullanabilirz ilgili kayıt bulamazsa bize bir exception fırlatır .FirstOrDefault() kullanırsak ilgili kayıdı bulamazsa bize bir null değer gönderir
                //gelen sorguyu ise foreach ile ekrana yazdıraşom

                foreach (var item in result)
                {
                Console.WriteLine($"name: {item.Name} price: {item.Price}");
                }

            }
        }

        //Veritabanından bir ürün almak istediğimizde ne yapıcaz id bilgisi girdiğimizde tablodaki o bilgiyi tablodaki id bilgisiyle eşleşen bilgiyi getiren bir metot
        //gönderdiğimiz bilgiye göre ürün bilgisini getiren metot 
        static void GetProductById(int id)
        {
            //Context nesenesini oluşturalım
            using (var context = new ShopContext())
            {
                //context.Products bunu dediğimizde Products listesinin bir referansını almış oluruz
                var result = context.Products.Where(p => p.Price > 1000 && p.ProductId == id).FirstOrDefault();
                //iki adet filrteleme ekledik && ile fiyatı 1000 den büyük olanları da ekledik
                //bu referans üzerinden belli kriterler belli sorgulama kriterleri ekleyebiliiriz mesela tüm bilgileri değilde fiyatı 1000 den yüksek olanları getir gibi belli filrteler ekleyip en sonda bu sorguyu çalıştırmamız gerekiyor bu sorguyu en son databaseye göndermek için .SaveChanges() diyorduk ya aynı işi yapan burda da .ToList() eklemeliyiz
                //sonuç benim için bir liste olmasın sadece tek bir prodct objesi olsun istiyorsam .First() kullanabilirz ilgili kayıt bulamazsa bize bir exception fırlatır .FirstOrDefault() kullanırsak ilgili kayıdı bulamazsa bize bir null değer gönderir
                //gelen sorguyu ise foreach ile ekrana yazdıraşom
         
                    Console.WriteLine($"name: {result.Name} price: {result.Price}");
                
            }
        }
        //Bütün ürünleri bize getiren bir metot yazalım
        static void GetAllProducts()
        {
            //Context nesenesini oluşturalım
            using (var context = new ShopContext())
            {
                //context.Products bunu dediğimizde Products listesinin bir referansını almış oluruz
                //.Select(p => new {p.Name,p.Price}) kullanımı ile belii kolonları çağırırız *from yerine
                var products = context.Products.Select(p => new {p.Name,p.Price}).ToList();
                //bu referans üzerinden belli kriterler belli sorgulama kriterleri ekleyebiliiriz mesela tüm bilgileri değilde fiyatı 1000 den yüksek olanları getir gibi belli filrteler ekleyip en sonda bu sorguyu çalıştırmamız gerekiyor bu sorguyu en son databaseye göndermek için .SaveChanges() diyorduk ya aynı işi yapan burda da .ToList() eklemeliyiz
                //gelen sorguyu ise foreach ile ekrana yazdıraşom
                foreach (var p in products)
                {
                    Console.WriteLine($"name: {p.Name} price: {p.Price}");
                }
            }
        }
       
        //veritabanına product tabloya birden çok kayıt eklemek için metot
        static void AddProducts()
        {
            //tablolara kayıt eklicez
            //ShopContext'ten bir nesne üretelim bunu using içerisine alırsak işimiz bittiği zaman direkt bellekten silinmiş olur otomatikmen
            using (var db = new ShopContext())
            {

                //birden fazla ürün eklemek için
                var products = new List<Product>()
                {
                //ve burada bir nesne üretelim Product nesnesi ve içerisindeki bilgileri dolduralım
                new Product { Name = "Samsung S6", Price = 3000 },
                new Product { Name = "Samsung S7", Price = 4000 },
                new Product { Name = "Samsung S8", Price = 5000 },
                new Product { Name = "Samsung S9", Price = 6000 }
                };
                //tüm listeyi foreach ile ekleyebiliriz
                //ve bu bilgiyi .Add ile uygulamadı Products'a ekleyelim
                //foreach (var p in products)
                //{
                //db.Products.Add(p);
                //}
                //BUNU YAPABİLİRİZ VEYA BUNA ALTERNATİF OLARAK bunun için özellştirilmiş bir metot var onu kullanabiliriz
                db.Products.AddRange(products);
                //bu şekilde yapınca bu bilgi direkt veritabanına gitmiyor bu yüzden .SaveChanges() dediğimizde bekleyen değişikliklerin hepsi databaseye aktarılır yani sorgu oluşturma aşaması burası sorgu databaseye aktarılacak
                db.SaveChanges();
                Console.WriteLine("veriler eklendi.");
            }
        }
        //veritabanında prdoct tablosuna tek bir ürün ekleyecek metot

        static void AddProduct()
        {
            //tablolara kayıt eklicez
            //ShopContext'ten bir nesne üretelim bunu using içerisine alırsak işimiz bittiği zaman direkt bellekten silinmiş olur otomatikmen
            using (var db = new ShopContext())
            {
                //ve burada bir nesne üretelim Product nesnesi ve içerisindeki bilgileri dolduralım
                var p = new Product { Name = "Samsung S11", Price = 9000 };


                db.Products.Add(p);
                //bu şekilde yapınca bu bilgi direkt veritabanına gitmiyor bu yüzden .SaveChanges() dediğimizde bekleyen değişikliklerin hepsi databaseye aktarılır yani sorgu oluşturma aşaması burası sorgu databaseye aktarılacak
                db.SaveChanges();
                Console.WriteLine("veriler eklendi.");
            }
        }
    }
}



