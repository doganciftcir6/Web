using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.businness.Abstract
{
   public interface IProductService : IValidator<Product>
    {
        //her tablo için olacak temel metotları buraya alıyoruz aslında içi boş tabi imza olarak yazıyoruz bunların içleri Concrete klasörü içinde dolacak veritabanına göre özgü olarak
        Product GetById(int id);
        Product GetProductDetails(string url);
        //katagori filtreleme için
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetAll();
        //ansayfada belli ürünleri göstermek için
        List<Product> GetHomePageProducts();
        //kelimeye göre ürün aramak için
        List<Product> GetSearchResult(string searchString);
        bool Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        bool Update(Product entity, int[] categoryIds);
    }
}
