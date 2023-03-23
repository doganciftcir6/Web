using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using shopapp.businness.Abstract;
using shopapp.businness.Concrete;
using shopapp.dataacces.Abstract;
using shopapp.dataacces.Concrete.EfCore;
using shopapp.webui.EmailServices;
using shopapp.webui.Identity;

namespace shopapp.webui
{
    public class Startup
    {
        //email onayý vs için appsettings.json içindeki bilgileri buraya almak için
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //buraya servislerimizi ekliyoruz
            //ýdentity
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=shopDb"));
            //AddDefaultTokenProviders parola sýfýrlamak için benzersiz sayý üretecek olan metot
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            //options üzerinden özelliklerimizi yapýcaz
            services.Configure<IdentityOptions>(options => {
                //þifre iþlemleri password
                //RequireDigit ile kullanýcýnýn girdiði þifrede mutlaka sayýsal bir deðer olmasýný saðlarýz
                options.Password.RequireDigit = true;
                //parola mutlaka bir küçük harf olmak zorunda RequireLowercase
                options.Password.RequireLowercase = true;
                //parolada mutlaka bir büyük harf olmak zorunda RequireUppercase
                options.Password.RequireUppercase = true;
                //RequiredLength ile paroalda mutlaka 6 harf minimum olmak zorunda
                options.Password.RequiredLength = 6;
                //parolada mutlaka bir alphanumeric olmak zorunda @ _ gibi bir karakter olmak zorunda
                options.Password.RequireNonAlphanumeric = true;

                //lockout iþlemleri kullanýcýnýn hesabýnýn kilitlenip kilitlenmemsiyle alakalý durum
                //RequiredLength bu durumda kullanýcý yanlýþ bir parolayý maksimum 5 kere girebilir
                options.Lockout.MaxFailedAccessAttempts = 5;
                //5 kere yanlýþ girip hesabý kilitlendikten sonra TimeSpan.FromMinutes ile 5 dakika sonra tekrar giriþ yapmayý deneyebilir diyebiliriz 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //lockout'un aktif olmasý için
                options.Lockout.AllowedForNewUsers = true;

                //AllowedUserNameCharacters kullanýcýn username içerisinde olmasýný istediðiniz karakterleri buraya yazabiliyoruz
                //options.User.AllowedUserNameCharacters = "";
                //RequireUniqueEmail ile her kullancýnýn mutlaka birbirinden farklý bir mail adresi olmasý gerekiyor
                options.User.RequireUniqueEmail = true;
                //bir kullanýcý üye olur ancak üye olduktan sonra mutlaka hesabýný onaylamasý gerekir.
                options.SignIn.RequireConfirmedEmail = true;
                //verdiði telefon numarasý içinde bir onay olmasý gerekir RequireConfirmedPhoneNumber
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });
            //Cookie ayarlarýný yapalým
            //Cookie kullanýcýnýn tarayýcýsýnda uygulama tarafýndan býrakýlan bir bilgidir
            //örneðin arama motoruna bir arama yaparýz daha sonra aradýðýmýz ile ilgili reklamlar daha sonra karþýmýza çýkar iþte bunlarýn hepsi cookiler aracýðýyla yapýlýyor yaptýðýmýz aramalar sonucunda tarayýcýlarýmýza belli uygulamalar býrakýyor ve bizi daha sonraki aþamalarda tanýyor cookileri tarayýcalara bu yüzden býrakýyoruz cookilere göre uygulama bizi tanýyor
            services.ConfigureApplicationCookie(options=> {
                //bir nedenden dolayý cookie ile seciton birbirini tanýmýyorsa bu durumda /account/login yönlendirme yapýlýr
                //kullanýcý siteye login yapmadýysa onu burada /account/login e yönlendiriyoruz yani AccountController daki Login action metotuna
                options.LoginPath = "/account/login";
                //çýkýþ iþlemi yaptýðým zaman cookie tarayýcýdan silinecek cookie ile section arasýnda bir baðlantý kalmayacaðýndan dolayý sonraki taleplerinizi yetkiniz olmayan alanalar için sizi /account/logout sayfasýna yönlendiriyor olmasý gerekiyor
                options.LogoutPath = "/account/logout";
                //örneðin ben sipariþi vermem için bir hesap oluþturmam benim için yeterli uygulamaya her login yapan kullanýcý sipariþ verebilir bunda sorun yok ancak her login olan kullanýcý yönetici sayfalarýný admin sayfalarýný görüntülemiyor olmasý gerekiyor burda bir yetki sözkonsuu bu yüzden yönetici sayfasýna gidemediðinde kullanýcýya AccessDeniedPath eriþimin engellendiðini göstereck olan bir sayfaya yönelendirme yapýyor
                //yani kullanýcý login yapmýþ tamam ancak yetkisi olmayan alana gitmeye çalýþtýðý zaman /account/accessdenied AcoountControllerdaki accessdenied action metotuna gönderiyoruz
                options.AccessDeniedPath = "/account/accessdenied";
                //SlidingExpiration bu durumda varsayýlan olan tarayacýmýza býrakýlan cookimizin sürezi 20 dakika biz 20 dakika uygulamaya hiç bir istek yapamazsak bu durumda 21. dakiakda cookimiz tarayýcýdan silinir ve tekrar login olmamýz için uygulama logincontrollerine gönderilir varsayýlan bu þekilde ancak SlidingExpiration true dersem bu durumda 15 dakikam kaldýysa bir istek yaptýðýmda süre sýfýrlanýr tekrar 20 dakikam olur ancak false dersem istediðim kadar istek yapayým toplam 20 dakikam var her türlü
                options.SlidingExpiration = true;
                //bu 20 dakika süresini deðiþtirebiliyoruz uygulamama gelen adam 60 dakika boyunca login olsun 60 dakika boyunca uygulama kullanýcýyý tanýyacak 60 dakika sonra tekrar login olmasý gerekir
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //CookieBuilder nesnesinin bazý özellikleri var
                options.Cookie = new CookieBuilder
                {
                    //HttpOnly cookieyi sadece bir http talebiyle biz elde edebiliriz mesela uygulama tarafýnda çalýþan bir javascript gelip bizim cookimize ulaþamasýn diyebiliriz 
                    HttpOnly = true,
                    //tarayýcýda olan cookienin ismini deðiþtirebiliriz
                    Name = ".ShopApp.Security.Cookie",
                    //SameSiteMode bu durumda b kullanýcýsý a kullanýcýsnýn cookie'sine sahip olsa bile sadece cookiyle session haberleþmesi için mutlaka adreste önemli yani a kullanýsýnýn bilgisayarý gerekli olur
                    SameSite = SameSiteMode.Strict
                };
            });

            // mvc
            // razor pages
            // productRepository çaðýrýldýðý zaman bunun dolu versiyonunun çaðrýlmasý gerekiyor dolayýsýyla startup dosyasýna gidelim önce sanal sýnýfý yazýcaz sonra çaðýrmak istediðimiz sanal sýnýfýn dolu halini yazýcaz
            //dataaccesle çalýþýrken bunu yapýoruz
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            //businnes katmaný içinde bunu yapýyoruz service çaðrýldýðý zaman ben producutmanageri göndericem
            // artýk projemiz önce IProductService ile çalýþacak businness katmaný yani
            services.AddScoped<IProductService, ProductManager>();
            //dinamkik ijekþýn iþlemi yapýlan category için
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            //mail onaylandýðý zaman cart objeisini oluþturularým daha sonra startupta ilgili inject iþlemlerinin karþýlýðýný service olarak eklememiz gerekiyor
            services.AddScoped<ICartRepository, EfCoreCartRepository>();
            services.AddScoped<ICartService, CartManager>();
            //sipariþ kaydý için
            services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
            services.AddScoped<IOrderService, OrderManager>();

            //email onayý için service eklememiz gerekiyor
            services.AddScoped<IEmailSender, SmtpEmailSender>(i=> new SmtpEmailSender(
                _configuration["EmailSender:Host"],
                _configuration.GetValue<int>("EmailSender:Port"),
                _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                _configuration["EmailSender:UserName"],
                _configuration["EmailSender:Password"]
                ));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration,UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //wwwroot un açýlmasý için bir middlewear eklememiz gerekiyordu
            app.UseStaticFiles(); //wwwroot altýndaki klasörler açýlmýþ oluyor
            //node_module'yi dýþarýya açalým
            app.UseStaticFiles(new StaticFileOptions {FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),RequestPath="/modules"});

            if (env.IsDevelopment())
            {
                //burada demek ki ben uygulama geliþtirme aþamasýndayým SeedDatabase'i burada kullanmam lazým zaten
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            //servisleri kullan dediðimiz yer UseAuthentication süreç içerisine bir servis yapýsýný eklemiþ oluyoruz
            app.UseAuthentication(); 
            app.UseRouting();
            //yetkilendirme için UseAuthorization eklememiz gerekiyor hata alýrýz yoksa
            app.UseAuthorization();

            // localhost:5000
            // localhost:5000/home
            // localhost:5000/home/index
            // localhost:5000/product/details/2
            // localhost:5000/product/list/2
            // localhost:5000/category/list


            app.UseEndpoints(endpoints =>
            {

                //order için
                endpoints.MapControllerRoute(
                    name: "orders",
                    pattern: "orders",
                    defaults: new { controller = "Cart", action = "GetOrders" }
            );

                //sipariþ detay için
                endpoints.MapControllerRoute(
                    name: "checkout",
                    pattern: "checkout",
                    defaults: new { controller = "Cart", action = "Checkout" }
            );

                //alýþveriþ sepeti bilgileri
                endpoints.MapControllerRoute(
                    name: "cart",
                    pattern: "cart",
                    defaults: new { controller = "Cart", action = "Index" }
            );


                //user editleme için route
                endpoints.MapControllerRoute(
                    name: "adminuseredit",
                    pattern: "admin/user/{id?}",
                    defaults: new { controller = "Admin", action = "UserEdit" }
            );
                //user listeleme için route
                endpoints.MapControllerRoute(
                    name: "adminusers",
                    pattern: "admin/user/list",
                    defaults: new { controller = "Admin", action = "UserList" }
            );


                //role listeleme için route
                endpoints.MapControllerRoute(
                    name: "adminroles",
                    pattern: "admin/role/list",
                    defaults: new { controller = "Admin", action = "RoleList" }
            );
                //role create için route
                endpoints.MapControllerRoute(
                    name: "adminrolecreate",
                    pattern: "admin/role/create",
                    defaults: new { controller = "Admin", action = "RoleCreate" }
            );
                //role edit için route
                endpoints.MapControllerRoute(
                    name: "adminroleedit",
                    pattern: "admin/role/{id?}",
                    defaults: new { controller = "Admin", action = "RoleEdit" }
            );





                //admin paneli listeleme için route
                endpoints.MapControllerRoute(
                    name: "adminproducts",
                    pattern: "admin/products",
                    defaults: new { controller = "Admin", action = "ProductList" }
            );
                //ekleme formu için
                //admin paneli listeleme için product için route
                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/products/create",
                    defaults: new { controller = "Admin", action = "ProductCreate" }
            );
                //admin paneli product güncelleme için route
                endpoints.MapControllerRoute(
                    name: "adminproductedit",
                    pattern: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "ProductEdit" }
            );
                //admin paneli listeleme için category için route
                endpoints.MapControllerRoute(
                    name: "admincategories",
                    pattern: "admin/categories",
                    defaults: new { controller = "Admin", action = "CategoryList" }
            );

                //ekleme formu için
                //admin paneli listeleme için category için route
                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/categories/create",
                    defaults: new { controller = "Admin", action = "CategoryCreate" }
            );
                //admin paneli category güncelleme için route
                endpoints.MapControllerRoute(
                    name: "admincategoryedit",
                    pattern: "admin/categories/{id?}",
                    defaults: new { controller = "Admin", action = "CategoryEdit" }
            );


                //kelimeye göre ürün arama için route
                //localhost/search
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Shop", action = "search" }
            );
                //ürün bilgilerinin düzenlenmesi için route
                endpoints.MapControllerRoute(
                    name: "productdetails",
                    pattern: "{url}",
                    defaults: new { controller = "Shop", action = "details" }
            );

                //varsayýlan raoute kullanmak yerine ekstradan raoute yapabiliyoruz
                //kategori adýna göre ürün filtrelemesi yapmak için
                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "products/{category?}",
                    defaults: new {controller ="Shop",action ="list" }
            );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );
            });
            //seed user
            SeedIdentity.Seed(userManager,roleManager,configuration).Wait();
        }
    }
}
