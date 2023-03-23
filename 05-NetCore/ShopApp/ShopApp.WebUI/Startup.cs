using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //burada servislerimizi proje içerisine dahil ediyoruz
            //mvc
            //razor pages
            //BU AddControllersWithViews metotunu çaðýrýyoruz sebebi ise asp.net.core içerisinde mvc yapýsý mevcut bide buna alternatif olarak razor pages isminde  bir yapý mevcut ben mvc kullanýcam razor pages içinde controller kavramý yok yani burada viewler ile controllerlarý kullanacaðýmýzý söylüyoruz
            services.AddControllersWithViews();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();

            //router ayarlamasý yapabiliriz
            //localhost:5000
            //localhost:5000/home
            //localhost:5000/product/details/2
            //localhost:5000/product/list/3
            //yani uygulamamýza gelen istekleri nasýl deðerlendireceðimiz bize kalmýþ
            //istediðimiz bir routing þemasý kurabiliriz
            app.UseEndpoints(endpoints =>
            {
                //burada uygulamananýn ana dizinine sahip / bir istek geldiðinde request yani bir response göndermek 
                endpoints.MapControllerRoute(
                    name:"default",
                    //3 bölmeli bir router'ýmýz olsun
                    //burada router þemasýný oluþturuyoruz ? eklediðimiz zaman her zaman 3. parametreyi göndermek istemeyebiliriz bu durumda id kýsmý olsun ya da olmasýn 2 tane url'de bizim için geçerli olur yani localhost:5000/home/product þeklinde 2 parametre girmek zorundayýz burada üçüncü kýsým olan ýd kýsmýný da girmiþ olsak yani localhost:5000/home/product/5 demiþ olsak yine 2 parametre girmiþ gibi çalýþýr eðer ýd kýsmýný bulamazsa çünkü üçüncü bölme isteðe baðlý
                    //birincisi controller ismi ikincisi controller altýnda nereye gitsin controller içlerindeki metotlar oluyor yani üçüncü bölme isteðe baðlý üçüncü gönderdiðimiz id ise metotlarýn parametre içi oluyor
                    //buradaki þemeya göre gelen istekleri deðerlendirebiliyoruz
                    //Contoller=Home dersek bizim artýk uygulamamýzda bir controller çaðýrmasak bile bizi Home controller'a yönlendirir
                    //aciton=Index dediðimizde ise varsayýlan olarak Index metotunu çaðýrabiliyoruz
                    pattern: "{controller=Home}/{action=Index}/{id?}"
               );
            });
        }
    }
}
