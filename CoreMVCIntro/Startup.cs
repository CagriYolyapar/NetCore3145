using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCIntro.Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreMVCIntro
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
            services.AddControllersWithViews();
            //Hangi servisin kullanılacagını belirtiyorsunuz(Burada kullanmaktan ziyade burada hazırlıyorsunuz. Alttaki metotta kullanacaksınız)...

            // Burada standart bir Sql baglantısı belirtmek istiyorsanız(sınıf icerisinde optionBuilder'in belirtilmesindense bu tercih edilir) burada belirlemelisiniz..

            //Pool kullanmak bir Singleton Pattern görevi görür...
            services.AddDbContextPool<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies()); //böylece baglantı ayarlarını burada belirlemiş olduk...

            //Yukarıdaki ifadede dikkat ederseniz UseLazyLoadingProxies kullanılmıstır. Bu durum, .Net Core'daki Lazy Loading'in sürekli tetiklenebilmesi adına environment'inizi garanti altına almanızı saglar...

            //Dikkat edin Authentication işlemini yapabilmek icin servisi burada yaratmanız gerekir...

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {

                options.LoginPath = "/Home/Login";
            
            });


            //Todo: Session service yaratılacak

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Authentication'i Authorization'dan önce vermeye özen gösterin!!!

            app.UseAuthentication(); //kullanıcı kim bunu algıla demektir

            app.UseAuthorization(); //authorization yetki var mı yok mu gibi durumlarda calısacak bir metottur...

            //Todo:Session service kullanılacak

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
