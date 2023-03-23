using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.entity
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        //bu CategoryId nerden gelcek Category aşağıdaki proptan gelecek
        public Category Category { get; set; }
        public int ProductId { get; set; }
        //bu ProductId nerden gelcek Product aşağıdaki proptan gelecek
        public Product Product { get; set; }
    }
}
