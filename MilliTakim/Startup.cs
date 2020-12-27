using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MilliTakim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MilliTakim.Areas.Identity.Data;
using MilliTakim.Data;

namespace MilliTakim
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
            services.AddRazorPages();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<WebContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            /*
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAcces", policy => policy.RequireRole("Admin"));
            });
            */

            /*services.AddDefaultIdentity<IdentityUser>(
        options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
            */
        }


        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<AuthUser>>();
            var dbContext = serviceProvider.GetRequiredService <AuthDbContext>();

            IdentityResult roleResult1;
            IdentityResult roleResult2;
            //Adding Admin Role
            var roleCheck1 = await RoleManager.RoleExistsAsync("Admin");
            var roleCheck2 = await RoleManager.RoleExistsAsync("User");
            if (!roleCheck1)
            {
                //create the roles and seed them to the database
                roleResult1 = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!roleCheck2)
            {
                //create the roles and seed them to the database
                roleResult2 = await RoleManager.CreateAsync(new IdentityRole("User"));
            }
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management

        /*    AuthUser user = await UserManager.FindByEmailAsync("ekrem@outlook");
            if (user != null)
            {
                await UserManager.AddToRoleAsync(user, "Admin");
            }
        */

            if(!dbContext.Users.Any(u => u.UserName == "ekrem"))
            {
                var adminUser = new AuthUser
                { UserName = "ekrem@outlook",
                  Email = "ekrem@outlook",
                  Ad = "Ekrem",
                  Soyad = "Ozgur"
                };
                var result = await UserManager.CreateAsync(adminUser, "ekrem123");
                await UserManager.AddToRoleAsync(adminUser, new IdentityRole("Admin").Name);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Futbolcu}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateUserRoles(serviceProvider).Wait();

        }
    }
}
