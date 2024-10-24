using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Music_Catalog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            var app = builder.Build();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            // получение данных
            app.MapGet("/api/artists", (ApplicationContext db) => db.Artists.ToList());

            app.Run();


        }
    }
}
