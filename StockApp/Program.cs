using Microsoft.EntityFrameworkCore;
using StockApp.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace StockApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer("Data Source=EMIRSNMEZ;Initial Catalog=MyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            });

            builder.Services.AddScoped<MyDbContext, MyDbContext>();

            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}
