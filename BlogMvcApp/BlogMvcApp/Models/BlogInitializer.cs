using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

//herhangi bir değişiklik olduğunda bunu otomatik algılayıp bunu veritabanına uydurması için bu sınıf var yoksa değişiklik olduğunda veritabanına silip yeniden oluşturmak gerekir.
//bir diğer avantajı veritabanı oluşturulma aşamasında dataseed yapabiliyor olmamaız
namespace BlogMvcApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            //kategorileri oluşturup context içerisinde ekleyelim o'da veritabanına eklesin seed verilerimiz olsun
            List<Category> kategoriler = new List<Category>()
            {
                new Category(){KategoriAdi = "C#"},
                new Category(){KategoriAdi = "Asp.net MVC"},
                new Category(){KategoriAdi = "Asp.net WebForm"},
                new Category(){KategoriAdi = "Windows Form"}
            };
            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();
            //bloglarımızı da aynı şekilde yapalım
            List<Blog> bloglar = new List<Blog>()
            {
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Resim="1.jpg",CategoryId=1},
                new Blog(){Baslik="C# Delegates",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Resim="1.jpg",CategoryId=1},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-30), Anasayfa=false, Onay=false, Resim="1.jpg",CategoryId=1},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-20), Anasayfa=true, Onay=true, Resim="2.jpg",CategoryId=2},
                new Blog(){Baslik="C# Gereic List Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-5), Anasayfa=true, Onay=false, Resim="2.jpg",CategoryId=2},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=false, Onay=false, Resim="2.jpg",CategoryId=2},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Resim="3.jpg",CategoryId=3},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=false, Onay=true, Resim="3.jpg",CategoryId=3},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-15), Anasayfa=true, Onay=true, Resim="3.jpg",CategoryId=3},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-17), Anasayfa=true, Onay=false, Resim="4.jpg",CategoryId=4},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Resim="4.jpg",CategoryId=4},
                new Blog(){Baslik="C# Delegates Hakkında",Aciklama="C# Delegates Hakkında", EklenmeTarihi = DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Resim="4.jpg",CategoryId=4}
            };
            foreach (var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}