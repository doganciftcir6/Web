using System;
using Uygulama_Interface_RepositoryPattern_1.DataAccess.Abstract;
using Uygulama_Interface_RepositoryPattern_1.DataAccess.Concrete;
using Uygulama_Interface_RepositoryPattern_1.Entity;

namespace Uygulama_Interface_RepositoryPattern_1
{
    //TÜM YAPTIKLARIMIZI BURADA KULLANALIM
    class ProductManager : IProductRepository
    {
        IProductRepository _repository;
        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }
        public void Create(Product entitiy)
        {
            _repository.Create(entitiy);
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
    class Program
    {
        static void Main(string[] args)
        {
            //ÜRÜN KAYDI YAPMAK İSTİYORUZ
            //var productDal = new EfProductDal();
            //productDal.Create(new Product());
            //var productDal2 = new MySqlProductDal();
            //productDal2.Create(new Product());

            var productDal = new ProductManager(new EfProductDal());
            var productDal2 = new ProductManager(new MySqlProductDal());
            productDal.Create(new Product());
            productDal2.Create(new Product());

            //injection => IProductRepository => EfProductDal()
        }
    }
}
