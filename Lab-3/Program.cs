using Laboratorium3.Models;
using Laboratorium3.Services;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Laboratorium3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");
            builder.Services.AddRazorPages();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IContactService, MemoryContactServices>();
            builder.Services.AddSingleton<IAlbumService, MemoryAlbumServices>();


           builder.Services.AddDbContext<Data.AppDbContext>();

            builder.Services.AddDefaultIdentity<IdentityUser>()       // dodać
    .AddRoles<IdentityRole>()                             //
    .AddEntityFrameworkStores<Data.AppDbContext>();     // 


            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
           
           builder.Services.AddTransient<IAlbumService, EFAlbumService>();
           builder.Services.AddTransient<IContactService, EFContactService>();
            builder.Services.AddMemoryCache();                        // dodać
            builder.Services.AddSession();                            // dodać 









            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();                                 // dodać
            app.UseAuthorization();                                  // dodać
            app.UseSession();                                        // dodać 
            app.MapRazorPages();                                     // dodać

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}