using System;
using System.Collections.Generic;
using System.Text;
using Uygulama_Interface_RepositoryPattern_1.DataAccess.Abstract;

namespace Uygulama_Interface_RepositoryPattern_1.Entity
{
    //EVET DİYELİM Kİ YARIN ÖBÜR GÜN MYSQL TEKNOLOJİSİNE GEÇTİK ESKİ PROJEDEKİ BİLGİLERİMİZİ VE METOTLARIMIZI ALMAK İÇİN TEK YAPMAMIZ GEREKEN İNTERFACELERİ İMPLEMENTE ETMEK
    //ARTIK ESKİ OLUŞTURDUĞUMUZ METOTLAR VE PROPLAR GELECEK TEK YAPMAMIZ GEREEKEN METOTLARIN İÇİNSE MYSQL KODLARINI YAZMAK
    class MySqlProductDal : IProductRepository
    {
        public void Create(Product entitiy)
        {
            Console.WriteLine("MYSQLProduct - Create");
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product[] GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public Product[] GetProductsByCategry(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
