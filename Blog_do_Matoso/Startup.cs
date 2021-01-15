using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog_do_Matoso.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Blog_do_Matoso.Business;
using Blog_do_Matoso.Interface;

namespace Blog_do_Matoso
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration=configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Reponsavel pela conexão com o meu banco de dados
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DBcontext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddScoped<IDataService , DataService>();
            services.AddScoped<ILoginUsuario , LoginUsuario>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app , IWebHostEnvironment env ,
            IServiceProvider serviceProvider
            )
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default" ,
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            serviceProvider.GetService<IDataService>().IniciaDB();

        }

    }
}
