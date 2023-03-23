using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    //bu şekilde sadece bir bilgiyi bir ürün bilgsiin temsil eden bilgiyi ayrı ayrı değişkenler içerisinde taşımak yerine bir model oluşturup html sayfasında çok daha güzel bir şekilde kullanabiliriz
    //bu product classı bizim için bir model yani bir ürün bilgisini bizim için taşıyacak ve buradaki ürün bilgisinden biz kopya oluşturmamız gerekiyor bunu nasıl kullanıcaz gidip ilgili productcontroller'da action metotunun içine gidelim
    public class Product
    {
        //burada product yani bir ürünün alabileceği özellikleri tanımlayalım
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    }
}
