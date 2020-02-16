using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBookRepository;
using PhoneBookRepository.Interfaces;
using PhoneBookRepository.Repository;
using PhoneBookRepository.StubRepository;

namespace PhoneBookMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddSingleton<IPersonRepository>(new StubPersonRepository());

            //services.AddSingleton<IPersonRepository>(new EFPersonRepository(new PhoneBookContext("Data Source=.\\SQLEXPRESS;Initial Catalog=TaskManager;Integrated Security=SSPI") ));

            var connectionString = Configuration.GetConnectionString("PhoneBookDatabase");

            services.AddSingleton<IPersonRepository>(new EFPersonRepository(new PhoneBookContext(connectionString)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
