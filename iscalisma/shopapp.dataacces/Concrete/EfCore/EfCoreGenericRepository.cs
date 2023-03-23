using Microsoft.EntityFrameworkCore;
using shopapp.dataacces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopapp.dataacces.Concrete.EfCore
{
    //generic kısma bir Entity göndericez bide Context vericez
    //bunu oluşturma sebebimiz her tablo için temel olan metotları burada dolduralım ki sonra tek tek tüm tabloların repositorylerinde tekrar tekrar aynı metotları yazmayalım temel metotlar burda dolsun sadece orda ekstra metotları dolduralım
    //EfCoreGenericRepository IEfCoreGenericRepository'deki metotları implemente edecek
    //burda TContext eklememizin sebebi şuanki ShopContext sqllite kullanıyor yarın öbür gün başka bir veritabanı ile çalışmak istesem yeni bir Context açıp oraya o veritabanı bağlantısını yapmam lazım bu yüzden context değişebilir yeni bir contextim olabilir bu yüzden TContext şeklinde contextide generic yapıyoruz contextimiz değiştiği zaman kodlarımızda sorun çıkmasın uyum sağlasın diye metot içlerindeki usinglerde bu yüzden varlar
    public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
        //TEntity mutlaka class türünde olacak diyebliyoruz
        where TEntity : class
        //TContext mutlaka DbContextten türünden olması gerekiyor ve new() ile nesnesi oluşturabilir yapıyoruz
        where TContext : DbContext, new()
    {
        //bu metotları DbContext üzerinden doldurucaz
        public void Create(TEntity entity)
        {
            //Bir veri eklerken
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            //silme işlemi yaparken
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            //bütün ürün bilgilerini alırken
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            //ıd ye göre tek bir ürün alırken
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public virtual void Update(TEntity entity)
        {
            //güncelleme yaparken
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
