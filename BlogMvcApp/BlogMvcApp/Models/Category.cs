using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        //her bir kategoriye ait olan birden fazla blog olacağı için list tipinde bire çok ilişki
        public List<Blog> Bloglar { get; set; }
    }
}