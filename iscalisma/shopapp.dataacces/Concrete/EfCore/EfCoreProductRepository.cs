﻿using Microsoft.EntityFrameworkCore;
using shopapp.dataacces.Abstract;
using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopapp.dataacces.Concrete.EfCore
{
    //sanal olarak oluşturduğumuz interface sınıflarını veritabanına özgü olarak burda doldurucaz bu product tablosunu ilgilendirecek
    //generic bir repository sınıfımız var burda o sınıfı kullanıcaz ve IProductRepository interfacesini kullanıcaz ekstra olan metotlar product'a özel olan metotlar IProductRepository den gelecek temel metotlar ise EfCoreGenericRepository dan gelecek onlar zaten o generic sınıfta tanıtıldı içleri orda dolduruldu burda tekrar doldurmanın bir anlamı yok burda sadece bu entity'e özel olan metotları ekstra metotları doldurucaz
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                                .Where(i => i.ProductId == id)
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(i=> i.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == category));
                }

                return products.Count();
            }
        }

        public List<Product> GetHomePageProduct()
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(i => i.IsApproved && i.IsHome == true).ToList();
            }
        }

        public List<Product> GetPopularProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProductDetails(string url)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(i => i.Url==url)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            using(var context = new ShopContext())
            {
                var products = context
                    .Products
                    .Where(i=> i.IsApproved)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));
                }
              
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetSearchResult(string searchString)
        {
            using (var context = new ShopContext())
            {
                var products = context
                    .Products
                    .Where(i => i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                    .AsQueryable();

                return products.ToList();
            }

        }

        public List<Product> GetTop5Products()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new ShopContext())
            {
                var product = context.Products
                    .Include(i=> i.ProductCategories)
                    .FirstOrDefault(i => i.ProductId == entity.ProductId);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Description = entity.Description;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;
                    product.IsApproved = entity.IsApproved;
                    product.IsHome = entity.IsHome;

                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        ProductId = entity.ProductId,
                        CategoryId = catid
                    }).ToList();
                    context.SaveChanges();
                }

            }
        }
    }
}
