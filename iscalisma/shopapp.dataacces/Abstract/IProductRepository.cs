using System;
using System.Collections.Generic;
using System.Text;
using shopapp.entity;

namespace shopapp.dataacces.Abstract
{
    //sanal bir sınıf oluşturucaz product'ları ilgilendiren
    //generic sınıfımız olduğu için artık o sınıftan bir türetme yapabiliriz
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);
        //kategori filtrelemesi için bir metot ekleyelim
        List<Product> GetProductsByCategory(string name,int page,int pageSize);
        //artık temel metotları burda tekrar tekrar yazmama gerek kalmadı
        //product entity'sine özel metotları yazmam gerekiyor ama ekstra metotları yani
        //popüler ürünleri almak istiyorum mesela ekstra metot ekleriz
        List<Product> GetPopularProducts();
        //en iyi 5 product getiren metot
        List<Product> GetTop5Products();
        //anasayfada ürün göstermek için
        List<Product> GetHomePageProduct();
        //kelimeye göre ürün arama için
        List<Product> GetSearchResult(string searchString);
        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);

    }
}
