using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Music_Catalog;
using ModulsDB;
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
            // артист
            app.MapGet("/api/artists", (ApplicationContext db) => db.Artists.ToList());
            app.MapPost("/api/artists", async (Artist artist, ApplicationContext db) =>
            {
                await db.Artists.AddAsync(artist);
                await db.SaveChangesAsync();
                return artist;
            });
            app.MapGet("/api/albums", async (ApplicationContext db) => 
            {
                return await db.Albums
                    .Include(album => album.Genre)
                    .Include(album => album.Artist)
                    .ToListAsync();
            });

            app.Run();



        }
    }
}
