using System;
using System.Collections.Generic;
using System.Text;
using Uygulama_Interface_RepositoryPattern_1.DataAccess.Abstract;
using Uygulama_Interface_RepositoryPattern_1.Entity;

namespace Uygulama_Interface_RepositoryPattern_1.DataAccess.Concrete
{
    //metotları ICategoryReposity interfacesinde tanımladık şimdi burda çağırıp kullanıcaz
    class EfCategoryDal : ICategoryRepository
    {
        public void Create(Category entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category[] GetCategories()
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
