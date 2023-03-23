using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.businness.Abstract
{
    public interface ICategoryService : IValidator<Category>
    {
        //her tablo için olacak temel metotları buraya alıyoruz aslında içi boş tabi imza olarak yazıyoruz bunların içleri Concrete klasörü içinde dolacak veritabanına göre özgü olarak
        Category GetById(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByIdWidthProducts(int categoryid);

        void DeleteFromCategory(int productId, int categoryId);
    }
}
