using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    //homecontroller projeye gelen istekleri karşılayacak olan bir class bu özel bir class dolayısıyla buna yetenek kazandırıcaz : Controller ile 
    //localhost:5000/home dediğimizde oluşturmuş olduğumuz router şeması bizi HomeController'a getirecek
    public class HomeController : Controller
    {
        //şemadaki ikinci eleman action dolayısıyla bizim buraya bir metot eklememiz gerekiyor
        //bu metota action metotu deniyor mvc'De
        //localhost:5000/home/index
        //Index'e gelen bir istek sonucunda geriye string bir bilgi döndürüyoruz geriye sabit bir string değer döndürmek yerine dinamik bir html sayfası döndürücez
        //geriye dönen View()'in bir IActionResult'dan türetilen bir response olduğunu bilelim
        //buradaki yani bu controller'daki eklediğimiz View()'ler Views veya ShARED klasörü altındaki Home klasöründe html dosyasını ararlar
        public IActionResult Index()
        {
            //.html sayfasındaki verileri dinamik hale getirmek için burada bir koşul yapalım
            //server'ın saatini almalıyız o andaki sadece saat bilgisiyle ilgilenicem
            int saat = DateTime.Now.Hour;
            //saat o anda kaçsa ona göre bir işlem yapıcam günaydın,iyigünlervs
            //saat 12 den büyükse İyi günler değilse günaydın
            string mesaj = saat > 12 ? "İyi Günler" : "Günaydın";
            //şimdi action metotundan ilgili View()'e bir bilgi taşımamız gerekiyor bunu ViewBag ile yapabiliriz Greeting İSMİNDE BİR DEĞİŞKEN TANIMLIYoruz.
            ViewBag.Greeting = mesaj;
            //ikinci bir alan tanımlayalım bu ismi veritabanından alabiliriz tabiki ama şimdilik böyle ypaıcaz
            ViewBag.UserName = "Ahmet";
            return View();
        }
        //farklı bir metotta olabilir
        //localhost:5000/home/about
        public IActionResult About()
        {
            return View();
        }
        //yeni bir action metotu eklesem
        public IActionResult Contact()
        {
            //view() metotunun aşırı yüklenmiş farklı versiyonlarıda var
            //içersiine bir view name verebiliyoruz bu durumda Views klasörü içinde Home veya Shared klasörü için girmiş olduğumuz MyView.cshtml dosyasını arayacak yani html sayfalarını bu şekilde kendimiz adını verebiliyoruz bu sayfaya git diye
            return View("MyView");
        }
    }
}
