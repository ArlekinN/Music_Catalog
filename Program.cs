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
            // получение данных
            // артист
            app.MapGet("/api/artists", (ApplicationContext db) => db.Artists.ToList());
            app.MapGet("/api/artists/{id:int}", async (int id, ApplicationContext db) =>
            {
                Artist? artist = await db.Artists.FirstOrDefaultAsync(u => u.Id == id);

                if (artist == null) return Results.NotFound(new { message = "Артист не найден" });
                return Results.Json(artist);
            });
            app.MapGet("/api/artists/{name}", async (string name, ApplicationContext db) =>
            {
                Artist? artist = await db.Artists.FirstOrDefaultAsync(u => u.Name == name);

                if (artist == null) return Results.NotFound(new { message = "Артист не найден" });
                return Results.Json(artist);
            });
            // альбом
            app.MapGet("/api/albums", async (ApplicationContext db) => 
            {
                return  await db.Albums.ToListAsync();

            });
            app.MapGet("/api/albums/{id:int}", async (int id, ApplicationContext db) =>
            {
                Album? album = await db.Albums.FirstOrDefaultAsync(u => u.Id == id);

                if (album == null) return Results.NotFound(new { message = "Альбом не найден" });
                return Results.Json(album);
            });
            app.MapGet("/api/albums/{title}", async (string title, ApplicationContext db) =>
            {
                Album? album = await db.Albums.FirstOrDefaultAsync(u => u.Title == title); ;

                if (album == null) return Results.NotFound(new { message = "Альбом не найден" });
                return Results.Json(album);
            });
            // музыка
            app.MapGet("/api/songs", async (ApplicationContext db) =>
            {
                return await db.Songs.ToListAsync();

            });
            app.MapGet("/api/songs/{title}", async (string title, ApplicationContext db) =>
            {
                Song? song = await db.Songs.FirstOrDefaultAsync(u => u.Title == title); ;

                if (song == null) return Results.NotFound(new { message = "Песня не найдена" });
                return Results.Json(song);

            });
            app.MapGet("/api/songs/{id:int}", async (int id, ApplicationContext db) =>
            {
                Song? song = await db.Songs.FirstOrDefaultAsync(u => u.Id == id); ;

                if (song == null) return Results.NotFound(new { message = "Песня не найдена" });
                return Results.Json(song);

            });
            
            // жанр 
            app.MapGet("/api/genres", (ApplicationContext db) => db.Genres.ToList());
            app.MapGet("/api/genres/{id:int}", async (int id, ApplicationContext db) =>
            {
                Genre? genre = await db.Genres.FirstOrDefaultAsync(u => u.Id == id);
                
                if (genre == null) return Results.NotFound(new { message = "Жанр не найден" });

                return Results.Json(genre);
            });
            app.MapGet("/api/genres/{title}", async (string title, ApplicationContext db) =>
            {
                Genre? genre = await db.Genres.FirstOrDefaultAsync(u => u.Title == title);

                if (genre == null) return Results.NotFound(new { message = "Жанр не найден" });

                return Results.Json(genre);
            });
            // тип альбома 
            app.MapGet("/api/typealbums", (ApplicationContext db) => db.TypeAlbums.ToList());
            app.MapGet("/api/typealbums/{id:int}", async (int id, ApplicationContext db) =>
            {
                TypeAlbum? typeAlbum = await db.TypeAlbums.FirstOrDefaultAsync(u => u.Id == id);

                if (typeAlbum == null) return Results.NotFound(new { message = "Жанр не найден" });

                return Results.Json(typeAlbum);
            });

            //сборник
            app.MapGet("/api/collections", (ApplicationContext db) => db.Collections.ToList());
            app.MapGet("/api/collections/{title}", async (string title, ApplicationContext db) =>
            {
                Collection? collection = await db.Collections.FirstOrDefaultAsync(u => u.Title == title);

                if (collection == null) return Results.NotFound(new { message = "Коллекция не найден" });

                return Results.Json(collection);
            });
            // songCollection
            app.MapGet("/api/songcollections/{id:int}", async (int id, ApplicationContext db) =>
            {
               var songCollection = await db.SongCollections
                            .Where(u => u.CollectionId == id)
                            .ToListAsync();

                if (songCollection == null) return Results.NotFound(new { message = "Коллекция не найден" });

                return Results.Ok(songCollection);
            });
           

            // добавлени данных 
            // артист
            app.MapPost("/api/artists", async (Artist artist, ApplicationContext db) =>
            {
                await db.Artists.AddAsync(artist);
                await db.SaveChangesAsync();
                return artist;
            });
            // альбом
            app.MapPost("/api/albums", async (ApplicationContext db, [FromBody] Album album) =>
            {
                await db.Albums.AddAsync(album);
                await db.SaveChangesAsync();
                return album;
            });
            // тип альбома
            app.MapPost("/api/typealbums", async (ApplicationContext db, [FromBody] TypeAlbum typeAlbum) =>
            {
                await db.TypeAlbums.AddAsync(typeAlbum);
                await db.SaveChangesAsync();
                return Results.Json(typeAlbum);
            });
            // песня
            app.MapPost("/api/songs", async (ApplicationContext db, [FromBody] Song song) =>
            {
                await db.Songs.AddAsync(song);
                await db.SaveChangesAsync();
                return Results.Json(song);
            });
            // Сборник
            
            app.MapPost("/api/collections", async (ApplicationContext db, [FromBody] CollectionRequest request) =>
            {
                DirectorCollection directorCollection = new DirectorCollection();
                Collection collection;
                if (request.Genre == null)
                {
                    CollectionEpochBuilder builder = new CollectionEpochBuilder();
                    collection = directorCollection.Director(builder, request.Epoch, 0, "", request.Title);
                }
                else
                {
                    CollectionGenreBuilder builder = new CollectionGenreBuilder();
                    collection = directorCollection.Director(builder, 0, request.Genre.Id, request.Genre.Title, request.Title);
                }
                await db.Collections.AddAsync(collection);
                await db.SaveChangesAsync();
                return Results.Json(collection);
            });

            // SongCollection
            app.MapPost("/api/songcollections", async (ApplicationContext db, [FromBody] SongCollection songCollection) =>
            {

                await db.SongCollections.AddAsync(songCollection);
                await db.SaveChangesAsync();
                return Results.Json(songCollection);
            });



            app.Run();



        }
    }
}
