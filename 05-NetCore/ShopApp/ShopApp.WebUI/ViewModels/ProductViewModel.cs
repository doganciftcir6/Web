using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.ViewModels
{
    public class ProductViewModel
    {
        //bu şekilde 2 tane html sayfasına göndermek istediğim modeli burda paketleyebiliyorum
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
