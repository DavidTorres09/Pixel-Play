using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;  // Agregado para acceder a la configuraci�n
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace PixelPlay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregado: Configuraci�n para acceder a la cadena de conexi�n
            builder.Configuration.AddJsonFile("appsettings.json");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Agregado: Obtener la cadena de conexi�n desde la configuraci�n
            string connectionString = builder.Configuration.GetConnectionString("PixelPlay");

            // Agregado: Configurar el contexto de la base de datos
            builder.Services.AddDbContext<PixelPlayContext>(options => options.UseSqlServer(connectionString));

            using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<PixelPlayContext>();
                try
                {
                    dbContext.Database.OpenConnection();
                    Console.WriteLine("La conexi�n a la base de datos se estableci� correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al establecer la conexi�n a la base de datos: {ex.Message}");
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
