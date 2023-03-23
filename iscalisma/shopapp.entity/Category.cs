using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.entity
{
    //product ve category entityleri arasnda çoka çok ilişki olacak dolayısıyla ProductCategory diye bir jankşın entity ekleyelim
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        //çoka çok ilişki için 
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
