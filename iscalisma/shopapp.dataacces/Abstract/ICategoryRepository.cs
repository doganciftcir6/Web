using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.dataacces.Abstract
{
    //sanal bir sınıf oluşturucaz category'ları ilgilendiren
    //generic sınıfımız olduğu için artık o sınıftan bir türetme yapabiliriz
    public interface ICategoryRepository:IRepository<Category>
    {
        //artık temel metotları burda tekrar tekrar yazmama gerek kalmadı
        //Category entity'sine özel metotları yazmam gerekiyor ama ekstra metotları yani
        //popüler kategorileri veren bir metot yapalım mesela
        List<Category> GetPopularCategories();
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);
    }
}
