using shopapp.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopapp.webui.Models
{
    public class ProductModel
    {
        //modeli bir form için kullanabiliriz gidip form için product entity'ini kullanmaktansa bu şekilde bir model oluşturarak formun içeriğini bu modelden alabiliriz istediğimiz değişiklikleri özellikleri burada ekleyip çıkartabiliriz veya tüm bu özelliklerim hepsini kullanmak zorunda kalmayız admin panelinin createproduct.cshmtl sayfasını buraya bağlayabiliriz mesela
        public int ProductId { get; set; }
        //burada belli validation kuralları ekleyebiliriz burada eklememizin amacı modeli sadece belli sayfalarda kullandığımız için veritabanından gelen bilgileri etkilemez sadece kullanılan yerleri etkiler
        //[Display(Name="Name",Prompt ="Enter product name")]
        //[Required(ErrorMessage ="Name zorunlu bir alandır.")]
        //[StringLength(60,MinimumLength =5,ErrorMessage = "Ürün ismi 5 ile 10 karakter aralığında olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Url zorunlu bir alandır.")]
        public string Url { get; set; }
        //price'nin required işlemesi için nullable yapmalıyız ki değer girimlediği zaman null değer dönsün eğer yapmazsak değer girilmediği zaman 0 atanır required işlemez
        //[Required(ErrorMessage = "Price zorunlu bir alandır.")]
        //[Range(1,10000,ErrorMessage ="Price için 1-10000 arasında değer girmelisiniz.")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Description zorunlu bir alandır.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Description 5 ile 100 karakter aralığında olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "ImageUrl zorunlu bir alandır.")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List <Category> SelectedCategories { get; set; }
    }
}
