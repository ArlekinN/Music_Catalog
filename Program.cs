using Microsoft.EntityFrameworkCore;
using Music_Catalog;
using ModulsDB;

using Music_Catalog.Data;
using Microsoft.AspNetCore.Mvc;

namespace App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

                await context.Database.MigrateAsync();

                await Seed.SeedData(context);
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            // ��������� ������
            // ������
            app.MapGet("/api/artists", (ApplicationContext db) => db.Artists.ToList());
            app.MapGet("/api/artists/{id:int}", async (int id, ApplicationContext db) =>
            {
                Artist? artist = await db.Artists.FirstOrDefaultAsync(u => u.Id == id);

                if (artist == null) return Results.NotFound(new { message = "������ �� ������" });
                return Results.Json(artist);
            });
            // ������
            app.MapGet("/api/albums", async (ApplicationContext db) => 
            {
                return  await db.Albums.ToListAsync();

            });
            // ���� 
            app.MapGet("/api/genres", (ApplicationContext db) => db.Genres.ToList());
            app.MapGet("/api/genres/{id:int}", async (int id, ApplicationContext db) =>
            {
                Genre? genre = await db.Genres.FirstOrDefaultAsync(u => u.Id == id);
                
                if (genre == null) return Results.NotFound(new { message = "���� �� ������" });

                return Results.Json(genre);
            });
            

            // ��������� ������ 
            // ������
            app.MapPost("/api/artists", async (Artist artist, ApplicationContext db) =>
            {
                await db.Artists.AddAsync(artist);
                await db.SaveChangesAsync();
                return artist;
            });
            // ������
            app.MapPost("/api/albums", async (ApplicationContext db, [FromBody] Album album) =>
            {
                await db.Albums.AddAsync(album);
                await db.SaveChangesAsync();
                return album;
            });


            app.Run();



        }
    }
}
