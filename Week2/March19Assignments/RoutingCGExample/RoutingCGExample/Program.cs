namespace RoutingCGExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
                pattern: "{controller=Home}/{action=Privacy}/{id?}");


            //app.MapControllerRoute(
            //     name: "studentgetallfull",
            //     pattern:"studs",
            //     defaults: new { Controller="Student", action="GetAllStudents"});


            //app.MapControllerRoute(
            //    name: "studentsingle",
            //    pattern: "studs/{id}",
            //    defaults: new { Controller = "Student", action = "GetStudent" });

            //app.MapControllerRoute(
            //    name: "fewcolumns",
            //    pattern: "studsfew",
            //    defaults: new { Controller = "Student", action = "fewcolumns" });


            app.Run();
        }
    }
}
