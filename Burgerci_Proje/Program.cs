using BLL.Abstract;
using BLL.Concrete;
using BLL.Mapping;
using DAL.AbstractRepositories;
using DAL.ConcreteRepository;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Burgerci_Proje
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //asdasd

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Dependency Injection

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IGarnitureService), typeof(GarnitureService));
            builder.Services.AddScoped(typeof(IDrinkService), typeof(DrinkService));

            // Automapper

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile), typeof(Burgerci_Proje.Mapping.AutoMapperProfile));

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
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
