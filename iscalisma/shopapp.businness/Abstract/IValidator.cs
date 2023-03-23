using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.businness.Abstract
{
    //IValidator benim için her metotu kontrol edecek olan bana bu kontrolü sağlayacak olan generic bir interface product,category ya da order için çalışabilecek herhangi bir entity tipi için
    public interface IValidator<T>
    {
        string ErrorMessage { get; set; }
        //metot generic tipi alsın ve gelen entity'i validate etsin sonuç başarılı mı başarılı değil mi bize göndersin
        bool Validation(T entity);


    }
}
