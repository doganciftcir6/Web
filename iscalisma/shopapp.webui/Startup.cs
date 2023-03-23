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
        //email onay� vs i�in appsettings.json i�indeki bilgileri buraya almak i�in
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
            //�dentity
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=shopDb"));
            //AddDefaultTokenProviders parola s�f�rlamak i�in benzersiz say� �retecek olan metot
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            //options �zerinden �zelliklerimizi yap�caz
            services.Configure<IdentityOptions>(options => {
                //�ifre i�lemleri password
                //RequireDigit ile kullan�c�n�n girdi�i �ifrede mutlaka say�sal bir de�er olmas�n� sa�lar�z
                options.Password.RequireDigit = true;
                //parola mutlaka bir k���k harf olmak zorunda RequireLowercase
                options.Password.RequireLowercase = true;
                //parolada mutlaka bir b�y�k harf olmak zorunda RequireUppercase
                options.Password.RequireUppercase = true;
                //RequiredLength ile paroalda mutlaka 6 harf minimum olmak zorunda
                options.Password.RequiredLength = 6;
                //parolada mutlaka bir alphanumeric olmak zorunda @ _ gibi bir karakter olmak zorunda
                options.Password.RequireNonAlphanumeric = true;

                //lockout i�lemleri kullan�c�n�n hesab�n�n kilitlenip kilitlenmemsiyle alakal� durum
                //RequiredLength bu durumda kullan�c� yanl�� bir parolay� maksimum 5 kere girebilir
                options.Lockout.MaxFailedAccessAttempts = 5;
                //5 kere yanl�� girip hesab� kilitlendikten sonra TimeSpan.FromMinutes ile 5 dakika sonra tekrar giri� yapmay� deneyebilir diyebiliriz 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //lockout'un aktif olmas� i�in
                options.Lockout.AllowedForNewUsers = true;

                //AllowedUserNameCharacters kullan�c�n username i�erisinde olmas�n� istedi�iniz karakterleri buraya yazabiliyoruz
                //options.User.AllowedUserNameCharacters = "";
                //RequireUniqueEmail ile her kullanc�n�n mutlaka birbirinden farkl� bir mail adresi olmas� gerekiyor
                options.User.RequireUniqueEmail = true;
                //bir kullan�c� �ye olur ancak �ye olduktan sonra mutlaka hesab�n� onaylamas� gerekir.
                options.SignIn.RequireConfirmedEmail = true;
                //verdi�i telefon numaras� i�inde bir onay olmas� gerekir RequireConfirmedPhoneNumber
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });
            //Cookie ayarlar�n� yapal�m
            //Cookie kullan�c�n�n taray�c�s�nda uygulama taraf�ndan b�rak�lan bir bilgidir
            //�rne�in arama motoruna bir arama yapar�z daha sonra arad���m�z ile ilgili reklamlar daha sonra kar��m�za ��kar i�te bunlar�n hepsi cookiler arac���yla yap�l�yor yapt���m�z aramalar sonucunda taray�c�lar�m�za belli uygulamalar b�rak�yor ve bizi daha sonraki a�amalarda tan�yor cookileri taray�calara bu y�zden b�rak�yoruz cookilere g�re uygulama bizi tan�yor
            services.ConfigureApplicationCookie(options=> {
                //bir nedenden dolay� cookie ile seciton birbirini tan�m�yorsa bu durumda /account/login y�nlendirme yap�l�r
                //kullan�c� siteye login yapmad�ysa onu burada /account/login e y�nlendiriyoruz yani AccountController daki Login action metotuna
                options.LoginPath = "/account/login";
                //��k�� i�lemi yapt���m zaman cookie taray�c�dan silinecek cookie ile section aras�nda bir ba�lant� kalmayaca��ndan dolay� sonraki taleplerinizi yetkiniz olmayan alanalar i�in sizi /account/logout sayfas�na y�nlendiriyor olmas� gerekiyor
                options.LogoutPath = "/account/logout";
                //�rne�in ben sipari�i vermem i�in bir hesap olu�turmam benim i�in yeterli uygulamaya her login yapan kullan�c� sipari� verebilir bunda sorun yok ancak her login olan kullan�c� y�netici sayfalar�n� admin sayfalar�n� g�r�nt�lemiyor olmas� gerekiyor burda bir yetki s�zkonsuu bu y�zden y�netici sayfas�na gidemedi�inde kullan�c�ya AccessDeniedPath eri�imin engellendi�ini g�stereck olan bir sayfaya y�nelendirme yap�yor
                //yani kullan�c� login yapm�� tamam ancak yetkisi olmayan alana gitmeye �al��t��� zaman /account/accessdenied AcoountControllerdaki accessdenied action metotuna g�nderiyoruz
                options.AccessDeniedPath = "/account/accessdenied";
                //SlidingExpiration bu durumda varsay�lan olan tarayac�m�za b�rak�lan cookimizin s�rezi 20 dakika biz 20 dakika uygulamaya hi� bir istek yapamazsak bu durumda 21. dakiakda cookimiz taray�c�dan silinir ve tekrar login olmam�z i�in uygulama logincontrollerine g�nderilir varsay�lan bu �ekilde ancak SlidingExpiration true dersem bu durumda 15 dakikam kald�ysa bir istek yapt���mda s�re s�f�rlan�r tekrar 20 dakikam olur ancak false dersem istedi�im kadar istek yapay�m toplam 20 dakikam var her t�rl�
                options.SlidingExpiration = true;
                //bu 20 dakika s�resini de�i�tirebiliyoruz uygulamama gelen adam 60 dakika boyunca login olsun 60 dakika boyunca uygulama kullan�c�y� tan�yacak 60 dakika sonra tekrar login olmas� gerekir
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //CookieBuilder nesnesinin baz� �zellikleri var
                options.Cookie = new CookieBuilder
                {
                    //HttpOnly cookieyi sadece bir http talebiyle biz elde edebiliriz mesela uygulama taraf�nda �al��an bir javascript gelip bizim cookimize ula�amas�n diyebiliriz 
                    HttpOnly = true,
                    //taray�c�da olan cookienin ismini de�i�tirebiliriz
                    Name = ".ShopApp.Security.Cookie",
                    //SameSiteMode bu durumda b kullan�c�s� a kullan�c�sn�n cookie'sine sahip olsa bile sadece cookiyle session haberle�mesi i�in mutlaka adreste �nemli yani a kullan�s�n�n bilgisayar� gerekli olur
                    SameSite = SameSiteMode.Strict
                };
            });

            // mvc
            // razor pages
            // productRepository �a��r�ld��� zaman bunun dolu versiyonunun �a�r�lmas� gerekiyor dolay�s�yla startup dosyas�na gidelim �nce sanal s�n�f� yaz�caz sonra �a��rmak istedi�imiz sanal s�n�f�n dolu halini yaz�caz
            //dataaccesle �al���rken bunu yap�oruz
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            //businnes katman� i�inde bunu yap�yoruz service �a�r�ld��� zaman ben producutmanageri g�ndericem
            // art�k projemiz �nce IProductService ile �al��acak businness katman� yani
            services.AddScoped<IProductService, ProductManager>();
            //dinamkik ijek��n i�lemi yap�lan category i�in
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            //mail onayland��� zaman cart objeisini olu�turular�m daha sonra startupta ilgili inject i�lemlerinin kar��l���n� service olarak eklememiz gerekiyor
            services.AddScoped<ICartRepository, EfCoreCartRepository>();
            services.AddScoped<ICartService, CartManager>();
            //sipari� kayd� i�in
            services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
            services.AddScoped<IOrderService, OrderManager>();

            //email onay� i�in service eklememiz gerekiyor
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
            //wwwroot un a��lmas� i�in bir middlewear eklememiz gerekiyordu
            app.UseStaticFiles(); //wwwroot alt�ndaki klas�rler a��lm�� oluyor
            //node_module'yi d��ar�ya a�al�m
            app.UseStaticFiles(new StaticFileOptions {FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),RequestPath="/modules"});

            if (env.IsDevelopment())
            {
                //burada demek ki ben uygulama geli�tirme a�amas�nday�m SeedDatabase'i burada kullanmam laz�m zaten
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            //servisleri kullan dedi�imiz yer UseAuthentication s�re� i�erisine bir servis yap�s�n� eklemi� oluyoruz
            app.UseAuthentication(); 
            app.UseRouting();
            //yetkilendirme i�in UseAuthorization eklememiz gerekiyor hata al�r�z yoksa
            app.UseAuthorization();

            // localhost:5000
            // localhost:5000/home
            // localhost:5000/home/index
            // localhost:5000/product/details/2
            // localhost:5000/product/list/2
            // localhost:5000/category/list


            app.UseEndpoints(endpoints =>
            {

                //order i�in
                endpoints.MapControllerRoute(
                    name: "orders",
                    pattern: "orders",
                    defaults: new { controller = "Cart", action = "GetOrders" }
            );

                //sipari� detay i�in
                endpoints.MapControllerRoute(
                    name: "checkout",
                    pattern: "checkout",
                    defaults: new { controller = "Cart", action = "Checkout" }
            );

                //al��veri� sepeti bilgileri
                endpoints.MapControllerRoute(
                    name: "cart",
                    pattern: "cart",
                    defaults: new { controller = "Cart", action = "Index" }
            );


                //user editleme i�in route
                endpoints.MapControllerRoute(
                    name: "adminuseredit",
                    pattern: "admin/user/{id?}",
                    defaults: new { controller = "Admin", action = "UserEdit" }
            );
                //user listeleme i�in route
                endpoints.MapControllerRoute(
                    name: "adminusers",
                    pattern: "admin/user/list",
                    defaults: new { controller = "Admin", action = "UserList" }
            );


                //role listeleme i�in route
                endpoints.MapControllerRoute(
                    name: "adminroles",
                    pattern: "admin/role/list",
                    defaults: new { controller = "Admin", action = "RoleList" }
            );
                //role create i�in route
                endpoints.MapControllerRoute(
                    name: "adminrolecreate",
                    pattern: "admin/role/create",
                    defaults: new { controller = "Admin", action = "RoleCreate" }
            );
                //role edit i�in route
                endpoints.MapControllerRoute(
                    name: "adminroleedit",
                    pattern: "admin/role/{id?}",
                    defaults: new { controller = "Admin", action = "RoleEdit" }
            );





                //admin paneli listeleme i�in route
                endpoints.MapControllerRoute(
                    name: "adminproducts",
                    pattern: "admin/products",
                    defaults: new { controller = "Admin", action = "ProductList" }
            );
                //ekleme formu i�in
                //admin paneli listeleme i�in product i�in route
                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/products/create",
                    defaults: new { controller = "Admin", action = "ProductCreate" }
            );
                //admin paneli product g�ncelleme i�in route
                endpoints.MapControllerRoute(
                    name: "adminproductedit",
                    pattern: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "ProductEdit" }
            );
                //admin paneli listeleme i�in category i�in route
                endpoints.MapControllerRoute(
                    name: "admincategories",
                    pattern: "admin/categories",
                    defaults: new { controller = "Admin", action = "CategoryList" }
            );

                //ekleme formu i�in
                //admin paneli listeleme i�in category i�in route
                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/categories/create",
                    defaults: new { controller = "Admin", action = "CategoryCreate" }
            );
                //admin paneli category g�ncelleme i�in route
                endpoints.MapControllerRoute(
                    name: "admincategoryedit",
                    pattern: "admin/categories/{id?}",
                    defaults: new { controller = "Admin", action = "CategoryEdit" }
            );


                //kelimeye g�re �r�n arama i�in route
                //localhost/search
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Shop", action = "search" }
            );
                //�r�n bilgilerinin d�zenlenmesi i�in route
                endpoints.MapControllerRoute(
                    name: "productdetails",
                    pattern: "{url}",
                    defaults: new { controller = "Shop", action = "details" }
            );

                //varsay�lan raoute kullanmak yerine ekstradan raoute yapabiliyoruz
                //kategori ad�na g�re �r�n filtrelemesi yapmak i�in
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
