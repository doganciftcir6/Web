using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.businness.Abstract;
using shopapp.webui.EmailServices;
using shopapp.webui.Extensions;
using shopapp.webui.Identity;
using shopapp.webui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopapp.webui.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        //_userManager bizim kullanıcı oluşturma login gibi temel rutin işlemlerimizi barındıran metotları barıdnırıyor inject
        private UserManager<User> _userManager;
        //_signInManager cookie olaylarını yönetecek inject
        private SignInManager<User> _signInManager;
        //mail onayı için inject
        private IEmailSender _emailSender;
        //cartmanager için inject
        private ICartService _cartService;
        //bunları inject işlemine tabi tutmamız gerekiyor
        //kanstraktır
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender,ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cartService = cartService;
        }
        //artık accountcontroller içeirisinde kullanıcı oluşturma ya da login gibi yada parola sıfırlama gibi rutin işlemlermizi barındıracak olan _userManager sınıfımız burda ve ayrıca cookie işlemlerini yöneteceğimiz bir _signInManager sınıfı burda var

        //ilgili logini eklememiz lazım action metotu olarak
        [HttpGet]
        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel() 
            { 
                ReturnUrl = ReturnUrl
            });
        }
        //ValidateAntiForgeryToken get metotu ile gönderilen token bilgisi eğer posta gelmiyorsa bu durumda burda bize bir hata verir işlemi gerçekleştirmiyor crosside ataklarının önüne geçiyor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Login(LoginModel model)
        {
            //LoginModel den gelen bilgileri model olarak taşcıaz
            if (!ModelState.IsValid)
            {
                //eğer isvalid değilse kurallara uymuyor demektir
                //aynı login sayfasını tekrer döndürelim ve model içerisinden gelen bilgileri sayfaya taşıyalım ki kullanıcı hatalı olduğu bilgileri görsün
                return View(model);
            }
            //bir hata yoksa kriterle uyuyorsa bu durumda user bilgsini veritabanından alalım bakalım veriabanında bu user bilgisi var mı 
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                //kullanıcı veritabanında yoksa
                //sayfaki asp-validation-summary="All" kısmında bu hata yazacak ve ilk parametresini boş bırakarak herhangi bir property ile ilişkilendirmeyelim sadece password ile ilişkilendirebilirdik mesela password yazarak
                ModelState.AddModelError("", "Bu kullanıcı adı daha önce hesap oluşturulmamış");
                return View(model);
            }
            //mail alanı onaylanmış mı diye soralım
            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                //onaylanmamışsa
                ModelState.AddModelError("", "Lütfen email hesabınıza gelen link ile üyeliğinizi onaylayınız.");
                return View(model);
            }
            //onaylamışsa
            //bu durumda kayıt var login işlemi yapabiliriz
            //1. paramete usernaem 2.parametre password bilgsii bekliyor
            //3. parametreye false dersek kullanıcı tarayıcıyı kapattığında çıkış yapmış olur cookiesi silnir
            //4. parametre kullanıcı başarısız bir giriş yaparsa bu adet özelliği açılsın mı kapatılsın mı onu belirtiyoruz
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                //başarılı bir sonuç gelmiş olur ve kullanıcı uygulamaya giriş yapmış olur
                //?? ile null değer kontrolü yaparız null değise ~/ ile uygulama anasayfasına gideriz
                return Redirect(model.ReturnUrl??"~/");
            }
            //bu durumda modelden gelen bir hata yok ancak kullanıcı bilgileri yanlış girmiş
            ModelState.AddModelError("", "Girilen kullanıcı adı veya parola yanlış");
            return View(model);
        }

        //kullanıcı oluşturma sayfası
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        //ValidateAntiForgeryToken get metotu ile gönderilen token bilgisi eğer posta gelmiyorsa bu durumda burda bize bir hata verir işlemi gerçekleştirmiyor crosside ataklarının önüne geçiyor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });
                // email
                await _emailSender.SendEmailAsync(model.Email, "Hesabınınızı onaylayınız.", $"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:44318{url}'>tıklayınız.</a>");
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("", "Bilinmeyen hata oldu lütfen tekrar deneyiniz.");
            return View(model);
        }
        //LOGOUT İŞLEMİ İÇİN
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage()
            {
                Title = "Oturum Kapatıldı.",
                Message = "Hesabınız güvenli bir şekilde kapatıldı.",
                AletyType = "warning"
            });
            return Redirect("~/");
        }

        //kullanıcı eposta onayı için
        //token bilgisi gelecek benzersiz bir sayı
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId==null || token == null)
            {
                //geçersiz link gelmiştir
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Geçersiz token.",
                    Message = "Geçersiz Token",
                    AletyType = "danger"
                }); 
                return View();
            }
            //user varsa
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                //bu durumda kullanıcı veritabanında vardır
                //hesabı onaylayabilriz
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //mail onaylandığı zaman cart objeisini oluşturularım daha sonra startupta ilgili inject işlemlerinin karşılığını service olarak eklememiz gerekiyor
                    _cartService.InitializeCart(user.Id);
                    //başarılı bir sonuç dönüyorsa
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Hesabınız onaylandı",
                        Message = "Hesabınız onaylandı",
                        AletyType = "success"
                    });
                    return View();
                }
            }
            //kullanıcı veritabanında yoktur
            TempData.Put("message", new AlertMessage()
            {
                Title = "Hesabınız onaylanmadı",
                Message = "Hesabınız onaylanmadı",
                AletyType = "warning"
            });
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        //şifremi unuttum sayfası için action metotu
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                //gelen email bilgisi boş ise
                return View();
            }
            //email bilgisi girildiyse bu bilgi veritabanında var mı bakalım
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                //veritabanında user bilgisi yoksa
                return View();
            }
            //eğer veritabanında user varsa
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            // generate token
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });
            // email
            await _emailSender.SendEmailAsync(Email, "Reset Password", $"Parolanızı yenilemek için linke <a href='https://localhost:44318{url}'>tıklayınız.</a>");
            return View();
        }
        //şifre yenileme için resetpassword actionu
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            //gelen userıd ve token doğruluğunu kontrol ediyoruz
            if(userId==null || token == null)
            {
                //hata varsa
                return RedirectToAction("Home", "Index");
            }
            //hata yoksa sayfaya taşıyalım
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }
        //şifre yenileme için resetpassword actionu yeni şifre girmesi için
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            //kullanıcı yeni parola bilgsini giremesi gerek
            if (!ModelState.IsValid)
            {
                //problem VARSA
                return View(model);
            }
            //problem yoksa 
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                //kullanıcı veritabanında yoksa
                return RedirectToAction("Home", "Index");
            }
            //kullanıcı veritabanında varsa resetleme işlemnii yaparız
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                //eğer sorunsuz işlem gerçekletiyse
                return RedirectToAction("Login", "Account");
            }
            //işlem gerçekleşmezse
            return View();
        }
        //yetkisiz bir alana gitmeye çalıştığımızda bu metot çalışacak bunu startup router olarak ayarlamıştık
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
