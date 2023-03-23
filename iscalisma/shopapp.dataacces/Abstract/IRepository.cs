using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.dataacces.Abstract
{
    //aynı metotlara sahip olacak entity'lerin tekrar tekrar abstract sınıfları içind aynı metotları yazmak yerine yerine generic bir repository oluşturursak işimiz daha kolay olur aynı metotları defalarca yazmak zorunda kalmayız
    //bu repostiyore <T> yerine hangi entity'i gönderirsek repositor o entity için çalışacak generic olmuş oldu
    public interface IRepository<T>
    {
        //her tablo için olacak temel metotları buraya alıyoruz aslında içi boş tabi imza olarak yazıyoruz bunların içleri Concrete klasörü içinde dolacak veritabanına göre özgü olarak
        T GetById(int id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
