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
            //burada servislerimizi proje i�erisine dahil ediyoruz
            //mvc
            //razor pages
            //BU AddControllersWithViews metotunu �a��r�yoruz sebebi ise asp.net.core i�erisinde mvc yap�s� mevcut bide buna alternatif olarak razor pages isminde  bir yap� mevcut ben mvc kullan�cam razor pages i�inde controller kavram� yok yani burada viewler ile controllerlar� kullanaca��m�z� s�yl�yoruz
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

            //router ayarlamas� yapabiliriz
            //localhost:5000
            //localhost:5000/home
            //localhost:5000/product/details/2
            //localhost:5000/product/list/3
            //yani uygulamam�za gelen istekleri nas�l de�erlendirece�imiz bize kalm��
            //istedi�imiz bir routing �emas� kurabiliriz
            app.UseEndpoints(endpoints =>
            {
                //burada uygulamanan�n ana dizinine sahip / bir istek geldi�inde request yani bir response g�ndermek 
                endpoints.MapControllerRoute(
                    name:"default",
                    //3 b�lmeli bir router'�m�z olsun
                    //burada router �emas�n� olu�turuyoruz ? ekledi�imiz zaman her zaman 3. parametreyi g�ndermek istemeyebiliriz bu durumda id k�sm� olsun ya da olmas�n 2 tane url'de bizim i�in ge�erli olur yani localhost:5000/home/product �eklinde 2 parametre girmek zorunday�z burada ���nc� k�s�m olan �d k�sm�n� da girmi� olsak yani localhost:5000/home/product/5 demi� olsak yine 2 parametre girmi� gibi �al���r e�er �d k�sm�n� bulamazsa ��nk� ���nc� b�lme iste�e ba�l�
                    //birincisi controller ismi ikincisi controller alt�nda nereye gitsin controller i�lerindeki metotlar oluyor yani ���nc� b�lme iste�e ba�l� ���nc� g�nderdi�imiz id ise metotlar�n parametre i�i oluyor
                    //buradaki �emeya g�re gelen istekleri de�erlendirebiliyoruz
                    //Contoller=Home dersek bizim art�k uygulamam�zda bir controller �a��rmasak bile bizi Home controller'a y�nlendirir
                    //aciton=Index dedi�imizde ise varsay�lan olarak Index metotunu �a��rabiliyoruz
                    pattern: "{controller=Home}/{action=Index}/{id?}"
               );
            });
        }
    }
}
