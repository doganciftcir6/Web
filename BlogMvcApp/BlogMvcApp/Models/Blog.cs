using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public string Icerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Onay { get; set; }
        public bool Anasayfa { get; set; }

        //bir blog birden fazla kategoride olabilir bire çok ilişkisi
        //nav prop aradaki bağlantı için uygulama tarafında
        //yabancı anahtar
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}