using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.BLL.Repositories;
using C44_G04_MVC03.DAL.Data.Contexts;
using C44_G04_MVC03.PL.Services;
using Microsoft.EntityFrameworkCore;

namespace C44_G04_MVC03.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepositories>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            builder.Services.AddDbContext<CompanyDBContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Singleton
                );

            builder.Services.AddScoped<IScopedService, ScopedService>(); // Per request
            builder.Services.AddScoped<ITransentService, TransentService>(); // Per Operation
            builder.Services.AddScoped<ISingletonService, SingletonService>(); // Per Application


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


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
