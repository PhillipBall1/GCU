using ProductsApp.Models;
using ProductsApp.Services;

namespace ProductsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IProductDAO, ProductDAO>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<IProductMapper, ProductMapper>(serviceProvider => 
            new ProductMapper(
                    builder.Configuration["ProductMapper:CurrencyFormat"],
                    builder.Configuration["ProductMapper:DateFormat"],
                    decimal.Parse(builder.Configuration["ProductMapper:TaxRate"]))
            );

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