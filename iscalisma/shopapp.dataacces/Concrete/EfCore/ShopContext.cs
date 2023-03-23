using Microsoft.EntityFrameworkCore;
using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.dataacces.Concrete.EfCore
{
    //Context işlemlerimizi burada yapıcaz ve tabi bunun için projeye Microsoft.EntityFramework eklemem gerekiyor ve Microsoft.EntityFramework.tools ve Microsoft.EntityFramework.design eklemem gerekiyor dataacces katmanına eklicez bunu
   public class ShopContext:DbContext
    {
        //entity'lerimizi dbset olarak eklememiz gerekiyor
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //onconfigure metotunu'da override etmemiz gerekiyor
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=shopDb");
        }
        //fluentapi ile çokçok tablosundaki birincil anahtarları burda belirtelim
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(c => new { c.CategoryId, c.ProductId });
        }
    }
}
