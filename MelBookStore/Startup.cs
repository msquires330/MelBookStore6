using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelBookStore.Models;
using Microsoft.AspNetCore.Http;

namespace MelBookStore
{
    public class Startup
    {
        // Configuration occurs in the startup file. 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Add a DbContext to the system and use SqlServer. Pass in the connection string for accessing the database. 
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:StoreConnection"]);
            });

            services.AddScoped<iStoreRepository, EFStoreRepository>();

            services.AddRazorPages();

            // You add both these services to make the cart functionality work (get the information to stick)
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
            // This will set up a session for us on startup 
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            // This is where you edit URLs
            app.UseEndpoints(endpoints =>
            {
                // Start with the most specific and go down to the most vague because it will just take the first one that applies and run with it. 

                // if they type in a category AND a page
                endpoints.MapControllerRoute("catpage",
                    "Books/{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                // if they give us only a page 
                endpoints.MapControllerRoute("page",
                    "Books/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                // if they give us only the category 
                endpoints.MapControllerRoute("category",
                    "Books/{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                // 
                endpoints.MapControllerRoute("pagination",
                    "Books/{pageNum}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
