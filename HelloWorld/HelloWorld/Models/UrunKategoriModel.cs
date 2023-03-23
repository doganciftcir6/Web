using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class UrunKategoriModel
    {
        public int UrunSayisi { get; set; }
        public List<Product> Urunler { get; set; }
    }
}