using shopapp.businness.Abstract;
using shopapp.dataacces.Abstract;
using shopapp.dataacces.Concrete.EfCore;
using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Text;

//yani bizim için ön bir filtreleme oluşturucak iş katmanı
//direkt sorguları veri tabanına göndermeden önce belli kontrolleri biz iş katmanında yapıcaz
//dolayısıyla bizim web projemiz artık dataacces katmanı yani EfCoreProductRepository ile direkt iletişime geçmeyek önce iş katmanı ile iletişime geçilecek
//iş katmanı dataacces ve entity katmanlarından faydalanır
namespace shopapp.businness.Concrete
{
   public class ProductManager : IProductService
    {
        //interface ile çalışırsam bağımlılık burda olmaz mesela artık biz EfCoreProduct yerine MySqlRepository'i artık kullanabiliriz ProductManager sınıfımız artık sanal bir sınıfla çalıştığı için
        private IProductRepository _productRepository;
        //kanstraktır oluşturarak inject işlemi yapalım
        public ProductManager(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public bool Create(Product entity)
        {
            //create işlemi yaptıktan sonra gelen entitiy ' i dataccesteki metot içerisine göndermek
            //iş kuralları uygula
            if (Validation(entity))
            {
            //sorun yoksa veritabanına ekleme işlemini yapalım
            _productRepository.Create(entity);
             return true;
            }
            //hata varsa
            return false;
        }

        public void Delete(Product entity)
        {
            //Bir ürünü silmeden önce belli kriteleri kontrol edebilirim
            //yani bizim için ön bir filtreleme oluşturucak iş katmanı
            //direkt sorguları veri tabanına göndermeden önce belli kontrolleri biz iş katmanında yapıcaz
            //iş kuralları
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            return _productRepository.GetHomePageProduct();
        }

        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name,int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(name, page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {

            _productRepository.Update(entity);
        }

        public bool Update(Product entity, int[] categoryIds)
        {
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "Ürün için en az bir kategori seçmelesiniz.";
                    return false;
                }
               _productRepository.Update(entity, categoryIds);
               return true;
            }
            return false;
        }
        public string ErrorMessage { get; set; }
        public bool Validation(Product entity)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "Ürün ismi girmelisiniz.\n";
                isValid = false;
            }
            if (entity.Price < 0)
            {
                ErrorMessage += "Ürün fiyatı negatif olamaz.\n";
                isValid = false;
            }
            return isValid;
        }
    }
}
