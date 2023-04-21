using foto.Models;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace foto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Models.PhotoContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=db_photo;Integrated Security=True;encrypt=false"));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Photo}/{action=Index}/{id?}");
            using (var scope = app.Services.CreateScope())
            using (var ctx = scope.ServiceProvider.GetService<PhotoContext>())
            {
                ctx!.Seed();
            }
            app.Run();
        }
    }
}