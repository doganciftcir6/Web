using BlogMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        //context nesnesi veritabanı işlemleri için
        private BlogContext context = new BlogContext();
        // GET: Home
        public ActionResult Index()
        {
            //veritabanı içindeki blogları cshtml'ye göndermek
            var bloglar = context.Bloglar
                    .Select(i=> new BlogModel()
                    {
                        Id = i.Id,
                        Baslik = i.Baslik.Length>100?i.Baslik.Substring(0,100)+"...":i.Baslik,
                        Aciklama = i.Aciklama,
                        EklenmeTarihi = i.EklenmeTarihi,
                        Anasayfa = i.Anasayfa,
                        Onay = i.Onay,
                        Resim = i.Resim
                    })
                    .Where(i => i.Onay == true && i.Anasayfa == true);
            return View(bloglar.ToList());
        }
    }
}