using Microsoft.EntityFrameworkCore;
using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopapp.dataacces.Concrete.EfCore
{
    //bu sınıfı verilerimizin otomatik eklemesi için oluşturalım
    public class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();
            //tanımlanan magreşınlar 0'a eşitse
            if(context.Database.GetPendingMigrations().Count() == 0)
            {
                //test verilerini veritabanına ekleyebilirim
                if (context.Categories.Count() == 0)
                {
                    //herhangi bir kategori daha önce eklenmediyse
                    context.Categories.AddRange(Categories);
                }
                //test verilerini veritabanına ekleyebilirim
                if (context.Products.Count() == 0)
                {
                    //herhangi bir kategori daha önce eklenmediyse
                    context.Products.AddRange(Products);
                    //çokaçok ilişkiyi ekleyelim
                    context.AddRange(ProductCategories);
                }
            }
            context.SaveChanges();
        }
        private static Category[] Categories = {
            new Category(){Name="Telefon",Url="telefon"},
            new Category(){Name="Bilgisayar",Url="bilgisayar"},
            new Category(){Name="Elektronik",Url="elektronik"},
            new Category(){Name="Beyaz Eşya",Url="beyaz-esya"}
        };
        private static Product[] Products = {
            new Product(){Name="Samsung S5",Url="samsung-s5",Price=2000,ImageUrl="1.jpg",Description="iyi telefon",IsApproved=true},
            new Product(){Name="Samsung S6",Url="samsung-s6",Price=3000,ImageUrl="2.jpg",Description="iyi telefon",IsApproved=false},
            new Product(){Name="Samsung S7",Url="samsung-s7",Price=4000,ImageUrl="3.jpg",Description="iyi telefon",IsApproved=true},
            new Product(){Name="Samsung S8",Url="samsung-s8",Price=5000,ImageUrl="4.jpg",Description="iyi telefon",IsApproved=false},
            new Product(){Name="Samsung S9",Url="samsung-s9",Price=6000,ImageUrl="5.jpg",Description="iyi telefon",IsApproved=true},
        };
        //çoka çok ilşkiyi kullanabilmek için gerekli olan yapı
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory(){Product = Products[0],Category=Categories[0]},
            new ProductCategory(){Product = Products[0],Category=Categories[2]},
            new ProductCategory(){Product = Products[0],Category=Categories[1]},
            new ProductCategory(){Product = Products[1],Category=Categories[0]},
            new ProductCategory(){Product = Products[1],Category=Categories[2]},
            new ProductCategory(){Product = Products[2],Category=Categories[0]},
            new ProductCategory(){Product = Products[2],Category=Categories[2]},
            new ProductCategory(){Product = Products[3],Category=Categories[0]},
            new ProductCategory(){Product = Products[3],Category=Categories[2]}
        };
    }
}
