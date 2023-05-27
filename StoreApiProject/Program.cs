using Microsoft.EntityFrameworkCore;
using StoreApiProject.Services;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace StoreApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
        ///    builder.Services.AddRazorPages();
        ///    

            builder.Services.AddControllers();
          System.Console.WriteLine("After controllers");

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-8CEBSKB\\SQLEXPRESS;Initial Catalog=StorageDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            });

            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IStoragesRepository, StoragesRepository>();
            builder.Services.AddScoped<IStateOfStoragesRepository, StateOfStoragesRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

        //    app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        //    app.MapRazorPages();
     //   using (var scope = app.Services.CreateScope())
     //   {
     //       using (var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
     //       {
     //           DbSeedingClass.SeedDataContext(dbContext);
     //       }
     //
     //   }


            app.Run();
           


        }

      
    }
}