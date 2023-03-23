using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.entity
{
    public class Product
    {
        //product ve category entityleri arasnda çoka çok ilişki olacak dolayısıyla ProductCategory diye bir jankşın entity ekleyelim
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
            public double? Price { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
            public bool IsApproved { get; set; }
            public bool IsHome { get; set; }
            //çoka çok ilişki için 
            public List<ProductCategory> ProductCategories { get; set; }
        }
    }

