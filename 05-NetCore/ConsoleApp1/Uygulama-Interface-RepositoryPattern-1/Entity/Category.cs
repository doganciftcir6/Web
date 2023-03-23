using System;
using System.Collections.Generic;
using System.Text;

namespace Uygulama_Interface_RepositoryPattern_1.Entity
{
    //BU ALAN UYGULAMADA VERİ TAŞIYACAK
    //örneğin kullanıcıdan bir ürün bilgisi alıcaz dolayısıyla Product tan bir nesne üretip nesne içerisindeki bilgiyi paketleyip örneğin databseye yollıcaz bilgi taşıcak bizim için ya da bir category oluşturmak istiyorsak categori bilgisini databaseden almak istiyorsak listeyi olduğu gibi alıp bir categori listesinin içerisine paketleyip bunları kullanıcılara göstericez
    //Id bilgisi çok önemli olduğu için bir karışıklık olmaması için interface şeklinde tanımladık ayrı olarak ve burada onu kullanalım
    class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
