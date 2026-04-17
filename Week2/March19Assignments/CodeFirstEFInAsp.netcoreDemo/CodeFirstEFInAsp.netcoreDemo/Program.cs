using CodeFirstEFInAsp.netcoreDemo.Models;
using CodeFirstEFInAsp.netcoreDemo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFInAsp.netcoreDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EventContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPost,PostRepository>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
