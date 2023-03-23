using System;
using System.Collections.Generic;
using System.Text;
using Uygulama_Interface_RepositoryPattern_1.Entity;

namespace Uygulama_Interface_RepositoryPattern_1.DataAccess.Abstract
//EfCateogyDal ve EfProdcutDal da aynı metotlar bulunuyor sadece ufak değişiklikler var dolayısıyla bu metotları bir interface içerisinde tanımlamak en mantıklısı
//ayrıca bu interfaceleri kullanama sebebimiz şaunda EF teknolojisini kullanıyoruz bu proje içinde ama ileriki zamanlarda farklı bir database yapısına farklı bir teknolojiye geçmek istediğimiz zaman metotları baştan bir ton düzenlemek yerine o teknoloji içinde bu interfaceten kalıtım yaparak aynı metotları sıkıntısız şekilde kullanabiliriz
{
    //ben gelip interfaceyi interfaceden türeticem generic olan intefaceden
    //benden bir parametre bekliyor <> içerisine Category interfacesinde olduğum için Category yazıcam oraya
    //Ve artık metotlarım otomatik olarak IRepository1 içerisinden gelmiş oluyor
    interface ICategoryRepository : IRepository1<Category>
    {
        Category[] GetCategories();

    }
}
