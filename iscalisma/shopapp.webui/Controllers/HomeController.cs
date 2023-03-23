using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.businness.Abstract;
using shopapp.dataacces.Abstract;
using shopapp.entity;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    // localhost:5000/home
    public class HomeController:Controller
    {
        //dataacces için nesne üretildiği anda bir injekşın yapmam gerekiyor
        // productRepository çağırıldığı zaman bunun dolu versiyonunun çağrılması gerekiyor dolayısıyla startup dosyasına gidelim
        //Businnes katmanından sonra homecontroller artık IProductService ile çalışacak kontrollerimizi bu iş katmanı üzerinde kolaylıkla yapıyor olucaz
        private IProductService _productService;
        //kanstraktır
        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult Index()
        {
            var productViewModel = new ProductListViewModel()
            {
                //ProductRepository içindeki _products listemizi bu şekilde alabiliriz get metotu sayesinde anasayfada belli ürünleri göstermek için getall değil
                Products = _productService.GetHomePageProducts()
            };

            return View(productViewModel);
        }

         // localhost:5000/home/about
        public IActionResult About()
        {
            return View();
        }

         public IActionResult Contact()
        {
            return View("MyView");
        }
    }
}