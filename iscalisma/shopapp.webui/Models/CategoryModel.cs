using shopapp.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopapp.webui.Models
{
    public class CategoryModel
    {
        //burada belli validation kuralları ekleyebiliriz burada eklememizin amacı modeli sadece belli sayfalarda kullandığımız için veritabanından gelen bilgileri etkilemez sadece kullanılan yerleri etkiler
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Kategori adı zorunludur.")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Kategori için 5-100 arasında değer giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Url alanı zorunludur.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Url alanı için 5-100 arasında değer giriniz.")]
        public string Url { get; set; }
        public List<Product> Products { get; set; }
    }
}
