using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDatabaseIslemleri
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ
            //context'i kullanabilmek için nesne
            UrunContext context = new UrunContext();
            //kategori bilgilerini almak
            // List<Kategori> kategoriler = context.Kategoriler.ToList();
            //var kategoriler = context.Kategoriler.ToList();

            //foreach (var kategori in kategoriler)
            //{
            //    Console.WriteLine("kategori id: {0} kategori adı: {1}",kategori.Id,kategori.KategoriAdi);
            //}
            //ürün bilgilerini almak
            //var urunler = context.Urunler.ToList();
            //foreach (var urun in urunler)
            //{
            //    Console.WriteLine("urun adı: {0} urun fiyatı: {1} urun stok adeti: {2}",urun.UrunAdi,urun.Fiyat,urun.StokAdedi);
            //}

            //tek bir ürünü almak
            //var urun = context.Urunler.Find(5);
            //Console.WriteLine("urun adı: {0} urun fiyatı: {1} urun stok adeti: {2}", urun.UrunAdi, urun.Fiyat, urun.StokAdedi);

            //update data
            //var urun = context.Urunler.Find(5);
            //Console.WriteLine("urun adı: {0} urun fiyatı: {1} urun stok adeti: {2}", urun.UrunAdi, urun.Fiyat, urun.StokAdedi);
            //urun.Fiyat = urun.Fiyat + (urun.Fiyat* 0.5);
            //urun.UrunAdi = "Samsung S6";
            //urun.StokAdedi = urun.StokAdedi + 100;
            //context.SaveChanges();

            //urun = context.Urunler.Find(5);
            //Console.WriteLine("urun adı: {0} urun fiyatı: {1} urun stok adeti: {2}", urun.UrunAdi, urun.Fiyat, urun.StokAdedi);

            //delete data
            //var urun = context.Urunler.Find(5);
            //if (urun != null)
            //{
            //    context.Urunler.Remove(urun);
            //}
            //context.SaveChanges();
            ////birden fazla delete data
            //var urunler = context.Urunler.ToList();
            //foreach (var urun2 in urunler)
            //{
            //    context.Urunler.Remove(urun2);
            //}
            //context.SaveChanges();
            //foreach (var item in urunler)
            //{
            //    Console.WriteLine("urun id: {0} urun adı: {1}",item.Id,item.UrunAdi);
            //}



        }
    }
}
