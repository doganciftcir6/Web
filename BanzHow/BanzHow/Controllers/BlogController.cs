using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanzHow.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            //Veritabanından bütün blog bilgileri al ve View Üzerine gönder.
            //Kendisibe gelen blog bilgilerini dinamik içerik üreten View yapısı bunu statik html'e çevirir.
            //bloglar
            //bu projede dinamik bir yapı kullanmadık kullanılan her şey static
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}