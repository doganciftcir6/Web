using System;
using System.Collections.Generic;
using System.Text;

namespace Uygulama_Interface_RepositoryPattern_1.Entity
{
    //Id bilgisi çok önemli olduğu için bir karışıklık olmaması için interface şeklinde tanımladık ayrı olarak
    //her bir sınıf için bir ıd bilgisinin de olmasını istediğimden dolayı ayrıcıyla
    public interface IEntity
    {
        int Id { get; set; }
    }
}
