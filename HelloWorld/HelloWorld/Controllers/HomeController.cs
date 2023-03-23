using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Kullanıcın isteklerinin karşılandığı yer controller'dır istek karşılandıktan sonra kullanılaraca kaynak sunuluyor bir html sayfası sunulabilir mesela
//isteğin türü ise controller içerisindeki action metotlarıyla karşılanıyor
//uygulama ilk çalıştığında varsayılan olarak HomeContoller altındaki İndex actionu çalıştırılır bu ayar App_Start altındaki RouteConfig'de tutuluyor
namespace HelloWorld.Controllers
{
    //veritabanına bağlanır ve bilgileri getirir.
    //getirilen bilgiler bir model içerisine yani bir sınıf içerisine aktarılır ve bu model view'e gönderilir
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //bu şekilde bu diziyi ilgili cshtml dosyasına göndermiş olduk ancak index.cshtml 'ninde kendisine gönderilen bilgiden haberi olması gerekiyor yani cshtml sayfasının bir modeli olması gerekiyor
            //Model kavramını kullanarak bu şekilde controller'dan view üzerine bir bilgi taşıdık
            //string[] kurslar = { "Mvc kursu", "web form kursu", "c# kursu" };
            //return View(kurslar);

            //model sınıfı oluşturduktan sonra
            //bu Model katmanından tanımlamış olduğum ürün listesini view üzerine göndericem
            //ilgili view model olarak bunu beklemesi gerekiyor
            List<Product> urunler = new List<Product>()
            {
                new Product(){UrunId=1,UrunAdi="Samsung S6",Aciklama="İdare eder",fiyat=1000,Satistami=true},
                new Product(){UrunId=2,UrunAdi="Samsung S7",Aciklama="İdare eder",fiyat=2000,Satistami=false},
                new Product(){UrunId=3,UrunAdi="Samsung S8",Aciklama="İdare eder",fiyat=3000,Satistami=true},
                new Product(){UrunId=4,UrunAdi="Iphone 6",Aciklama="İdare eder",fiyat=3000,Satistami=false},
                new Product(){UrunId=5,UrunAdi="Iphone 7",Aciklama="İdare eder",fiyat=4000,Satistami=true},
            };
            //bu listenin yanında ekstra bir bilgi göndermek istiyorsak veya ikinci bir liste göndermek istiyorsak view'a bu sefer ViewBag kullanırız sayfanın modeli tek bir tane olabilir dolayısıyla viewbag ile gönderiyoruz
            //UrunKategoriModel modeli oluşturulduktan sonra
            UrunKategoriModel model = new UrunKategoriModel();
            model.Urunler = urunler;
            model.UrunSayisi = urunler.Count();

            ViewBag.UrunSayisi = urunler.Count();
            return View(model);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}