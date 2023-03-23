using System;
using System.Collections.Generic;
using System.Text;

namespace Uygulama_Interface_RepositoryPattern_1.DataAccess.Abstract
{
    //IProductReposityry ve ICategoryReposityory ı ayrı ayrı tanımalamak yerine GENERİC bir interface tanımlasam işlerim daha kolay olur
    //iki intefacede ortak olan metotları buraya alıcam
    //ancak tip belirtmicem tip yerine <TEntity> yazıcaz tipi daha sonradan belirticez
    interface IRepository1<TEntitiy>
    {
        TEntitiy GetById(int id);
        void Update(TEntitiy entity);
        void Create(TEntitiy entitiy);
        void Delete(int id);
    }
}
