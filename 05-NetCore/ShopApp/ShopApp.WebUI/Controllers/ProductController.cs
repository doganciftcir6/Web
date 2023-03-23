using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class ProductController:Controller
    {
        //localhost:5000/product/Index
        //Index'e gelen bir istek sonucunda geriye string bir bilgi döndürüyoruz geriye sabit bir string değer döndürmek yerine dinamik bir html sayfası döndürücez
        //geriye dönen View()'in bir IActionResult'dan türetilen bir response olduğunu bilelim
        //buradaki yani bu controller'daki eklediğimiz View()'ler Views veya ShARED klasörü altındaki Product klasöründe html dosyasını ararlar
        public IActionResult Index()
        {
            //View'a veri aktarım yöntemleri
            //ViewBag
            //Model
            //ViewData

            //prodct modelinden bir nesne oluşturalım ve proplarının içini dolduralım
            var product = new Product { Name = "Iphone X", Price = 6000, Description = "güzel telefon" };
            //bunu sayfaya göndermek için viewData kullanabilirim
            //tanımlayacğaımız Product alanına product nesnesini direkt gönderebiliyoruz
            //ViewData["Product"] = product;
            //ViewData["Category"] = "Telefonlar";

            //VİEWBAG
            //ViewBag.Category = "Telefonlar";
            //ViewBag.Product = product;
            //return View();

            //MODEL
            ViewBag.Category = "Telefonlar";
            return View(product);
        }
        //localhost:5000/product/list
        public IActionResult List()
        {
            //ViewModels
            //Burda bir liste tanımlayalım
            var products = new List<Product>()
            {
                new Product {Name= "Iphone 8",Price=3000,Description="iyi telefon",IsApproved=true},
                new Product {Name= "Iphone X",Price=6000,Description="çok iyi telefon",IsApproved=false}
            };
            //bu şekilde bir liste tanımladık ve bu listeyi html sayfaya göndermek istiyoruz bu durumda 
            //peki sayafa bir kategori bilgisi göstermek istersek
            //var category = "Telefonlar";
            //ViewBag.Category = category;
            //peki category bu şekilde bir string değilde bir model olmuş olsa bunun için gidelim model klasöründe category modelini oluşturalım
            //var category = new Category()
            //{
            //    Name = "Telefonlar", Description="Telefon Kategorisi"
            //};
            //TEK BİR CATOGRY GÖNDERMEK YERİNE BİR LİSTE OLUŞTURALIM
            var categories = new List<Category>()
            {
               new Category() { Name = "Telefon", Description = "Telefon Kategorisi" },
               new Category() { Name = "Bilgisayar", Description = "Bilgisayar Kategorisi" },
               new Category() { Name = "Elektronik", Description = "Elektronik Kategorisi" }
            };
            //ViewBag.Category = category;
            //return View(products);
            //ben burda gelip tanımlamış olduğum ayrı ayrı 2 nesneyi html'ye ayrı ayrı göndermektense gelip bunları model içerisinde paketleyebilirim //ViewModels  isminde bir klasör ekleyelim bunun için paketleme işini orda yaptıktan sonra bir tanımlama yapalım
            var productViewModel = new ProductViewModel()
            {
                Categories = categories,
                Products = products
            };
            return View(productViewModel);

        }
        //farklı bir metotta olabilir
        //metota parametre verirsek bu şemada üçüncü eleman olarak gönderdiğimiz id'ye denk gelir
        //localhost:5000/product/details/5
        public IActionResult Details(int id)
        {
            //burda sayfaya bir bilgi göndermek istiyorum 
            //Bunlar veri tabanından gelecek tabi burda böyle bir kullanım yapıyoruz şimdilik
            //name: "samsung s6"
            //price: 3000
            //description: "iyi telefon"
            //bu bilgileri viewbag üzerinde tanımlayacak olduğum değişkenlerin içerisine atabilirim yani ilgili html sayfası içerisine taşıyabilirim
            //bu şekilde sadece bir bilgiyi bir ürün bilgsiin temsil eden bilgiyi ayrı ayrı değişkenler içerisinde taşımak yerine bir model oluşturup html sayfasında çok daha güzel bir şekilde kullanabiliriz
            //ViewBag.Name = "samsung s6";
            //ViewBag.Price = 3000;
            //ViewBag.Description = "iyi telefon";
            //return View();

            //Model klasoründe Product modelini oluşturduk şimdi onu kullanıcaz
            //oluşturduğumuz product classından bir kopya nesne oluşturucaz
            var p = new Product();
            //propların içini burda doldurabiliriz
            p.Name = "samsung s6";
            p.Price = 3000;
            p.Description = "iyi telefon";
            //şimdi burda tanımlamış olduğumuz p nesnesini biz View()'a html sayfasına yani göndermemiz gerekiyor
            //modeli view üzerine taşımış olduk
            //view'de bu modeli bekliyor olması gerekiyor Details.html ye gidelim ve modeli en başta orada tanımlayalım
            return View(p);
        }
    }
}
