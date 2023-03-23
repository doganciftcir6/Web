using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }
        //partialView'in action  metotu ile otomatik çalışan partialview'ler oluşturulabilir
        //ChildActionOnly ile sadece içerisinde bulunduğu view içerisinden çağırılabiliyor
        [ChildActionOnly]
        public PartialViewResult KategoriMenu()
        {
            List<Kategori> kategoriler = new List<Kategori>()
            {
                new Kategori(){KategoriAdı="Telefonlar",Id=1},
                new Kategori(){KategoriAdı="Tabletler",Id=2},
                new Kategori(){KategoriAdı="Laptoplar",Id=3}
            };
            return PartialView("KategoriMenu",kategoriler);
        }
    }
}