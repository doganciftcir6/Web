using System;
using System.Collections.Generic;
using System.Text;
using Uygulama_Interface_RepositoryPattern_1.DataAccess.Abstract;
using Uygulama_Interface_RepositoryPattern_1.Entity;

namespace Uygulama_Interface_RepositoryPattern_1.DataAccess.Concrete
{
    //metotları IproductReposity interfacesinde tanımladık şimdi burda çağırıp kullanıcaz
    class EfProductDal : IProductRepository
    {
        public void Create(Product entitiy)
        {
            Console.WriteLine("EFProduct - create");
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
