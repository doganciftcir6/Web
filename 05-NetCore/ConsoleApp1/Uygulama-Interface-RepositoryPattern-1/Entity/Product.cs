using System;
using System.Collections.Generic;
using System.Text;

namespace Uygulama_Interface_RepositoryPattern_1.Entity
{
    //BU ALAN UYGULAMADA VERİ TAŞIYACAK
    //Id bilgisi çok önemli olduğu için bir karışıklık olmaması için interface şeklinde tanımladık ayrı olarak ve burada onu kullanalım
    class Product : IEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
    }
}
