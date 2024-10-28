using ModulsDB;
using Microsoft.EntityFrameworkCore;
namespace Music_Catalog
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Collection> Collections { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<SongCollection> SongCollections { get; set; } = null!;
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           //Database.EnsureCreated();   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                    new Artist { Id = 1, Name = "Eminem" },
                    new Artist { Id = 2, Name = "Две тысячи ярдов" },
                    new Artist { Id = 3, Name = "IC3PEAK" },
                    new Artist { Id = 4, Name = "The Police" }
            );
            modelBuilder.Entity<Genre>().HasData(
                    new Genre { Id = 1, Title = "Rock" },
                    new Genre { Id = 2, Title = "Jazz" },
                    new Genre { Id = 3, Title = "Rap and Hip-hop" },
                    new Genre { Id = 4, Title = "Classic" },
                    new Genre { Id = 5, Title = "Electronic" },
                    new Genre { Id = 6, Title = "Disco" },
                    new Genre { Id = 7, Title = "Country" },
                    new Genre { Id = 8, Title = "Blues" },
                    new Genre { Id = 9, Title = "Reggae" },
                    new Genre { Id = 10, Title = "Indie" },
                    new Genre { Id = 11, Title = "Funk" },
                    new Genre { Id = 12, Title = "Alternative" }
            );
            modelBuilder.Entity<Album>().HasData(
                    new Album { Id = 1, Title = "Curtain Call: The Hits", YearRelease = 2005, Id_Genre = 3, Id_Artist = 1 },
                    new Album { Id = 2, Title = "The Eminem Show", YearRelease = 2002, Id_Genre = 3, Id_Artist = 1 },

                    new Album { Id = 3, Title = "Cпичка", YearRelease = 2023, Id_Genre = 1, Id_Artist = 2 },
                    new Album { Id = 4, Title = "Когда меня не станет главное не забудь…", YearRelease = 2024, Id_Genre = 12, Id_Artist = 2 },

                    new Album { Id = 5, Title = "Сказка", YearRelease = 2018, Id_Genre = 10, Id_Artist = 3 },

                    new Album { Id = 6, Title = "Certifiable", YearRelease = 2008, Id_Genre = 1, Id_Artist = 4 },
                    new Album { Id = 7, Title = "Flexible Strategies", YearRelease = 2018, Id_Genre = 1, Id_Artist = 4 }

            );
            modelBuilder.Entity<Song>().HasData(
                    new Song { Id = 1, Title = "Intro", YearRelease = 2005, Id_Genre = 3, Id_Artist = 1, Id_Album = 1, Duration = 0.33F },
                    new Song { Id = 2, Title = "Intro", YearRelease = 2005, Id_Genre = 3, Id_Artist = 1, Id_Album = 1, Duration = 0.33F },
                    new Song { Id = 3, Title = "The Way I Am", YearRelease = 2005, Id_Genre = 3, Id_Artist = 1, Id_Album = 1, Duration = 4.50F },
                    new Song { Id = 4, Title = "My Name is", YearRelease = 2005, Id_Genre = 3, Id_Artist = 1, Id_Album = 1, Duration = 4.28F },
                    new Song { Id = 5, Title = "Curtains Up", YearRelease = 2002, Id_Genre = 3, Id_Artist = 1, Id_Album = 2, Duration = 0.30F },
                    new Song { Id = 6, Title = "White America", YearRelease = 2002, Id_Genre = 3, Id_Artist = 1, Id_Album = 2, Duration = 5.24F },
                    new Song { Id = 7, Title = "Business", YearRelease = 2002, Id_Genre = 3, Id_Artist = 1, Id_Album = 2, Duration = 4.11F },

                    new Song { Id = 8, Title = "Спичка", YearRelease = 2023, Id_Genre = 1, Id_Artist = 2, Id_Album = 3, Duration = 1.38F },
                    new Song { Id = 9, Title = "Среди грязи и лести", YearRelease = 2024, Id_Genre = 12, Id_Artist = 2, Id_Album = 4, Duration = 2.50F },
                    new Song { Id = 10, Title = "Крыши частных секторов", YearRelease = 2024, Id_Genre = 12, Id_Artist = 2, Id_Album = 4, Duration = 2.09F },
                    new Song { Id = 11, Title = "Терабайтами пост-панка", YearRelease = 2024, Id_Genre = 12, Id_Artist = 2, Id_Album = 4, Duration = 2.05F },
                    new Song { Id = 12, Title = "По клубам", YearRelease = 2024, Id_Genre = 12, Id_Artist = 2, Id_Album = 4, Duration = 2.38F },
                    new Song { Id = 13, Title = "Юными навсегда", YearRelease = 2024, Id_Genre = 12, Id_Artist = 2, Id_Album = 4, Duration = 1.40F },


                    new Song { Id = 14, Title = "Считалочка", YearRelease = 2018, Id_Genre = 10, Id_Artist = 1, Id_Album = 5, Duration = 1.52F },
                    new Song { Id = 15, Title = "Сказка", YearRelease = 2018, Id_Genre = 10, Id_Artist = 1, Id_Album = 5, Duration = 2.45F },
                    new Song { Id = 16, Title = "Привет", YearRelease = 2018, Id_Genre = 10, Id_Artist = 1, Id_Album = 5, Duration = 2.45F },

                    new Song { Id = 17, Title = "Message In A Bottle", YearRelease = 2008, Id_Genre = 1, Id_Artist = 4, Id_Album = 6, Duration = 5.00F },
                    new Song { Id = 18, Title = "Walking On The Moon", YearRelease = 2008, Id_Genre = 1, Id_Artist = 4, Id_Album = 6, Duration = 6.19F },
                    new Song { Id = 19, Title = "Driven To Tears", YearRelease = 2008, Id_Genre = 1, Id_Artist = 4, Id_Album = 6, Duration = 5.50F },
                    new Song { Id = 20, Title = "Dead End Job", YearRelease = 2018, Id_Genre = 1, Id_Artist = 4, Id_Album = 7, Duration = 3.35F },
                    new Song { Id = 21, Title = "Landlord", YearRelease = 2018, Id_Genre = 1, Id_Artist = 4, Id_Album = 7, Duration = 3.07F }
            );
            modelBuilder.Entity<Collection>().HasData(
                new Collection { Id = 1, Title = "20x", TypeCollection = TypeCollection.Epoch, Epoch = 2020, Id_Genre = null },
                new Collection { Id = 2, Title = "10x", TypeCollection = TypeCollection.Epoch, Epoch = 2010, Id_Genre = null },
                new Collection { Id = 3, Title = "Rock Forever", TypeCollection = TypeCollection.Genre, Epoch = null, Id_Genre = 1 }
            );
            modelBuilder.Entity<SongCollection>().HasData(
                new SongCollection { Id_Song = 19, Id_Collection = 1 },
                new SongCollection { Id_Song = 20, Id_Collection = 1 },
                new SongCollection { Id_Song = 14, Id_Collection = 1 },

                new SongCollection { Id_Song = 17, Id_Collection = 2 },
                new SongCollection { Id_Song = 5, Id_Collection = 2 },
                new SongCollection { Id_Song = 6, Id_Collection = 2 },

                new SongCollection { Id_Song = 8, Id_Collection = 3 },
                new SongCollection { Id_Song = 17, Id_Collection = 3 },
                new SongCollection { Id_Song = 20, Id_Collection = 3 },
                new SongCollection { Id_Song = 21, Id_Collection = 3 }
            );
            modelBuilder.Entity<SongCollection>()
                .HasKey(sc => new { sc.Id_Song, sc.Id_Collection });

            modelBuilder.Entity<SongCollection>()
                .HasOne(sc => sc.Song)
                .WithMany(s => s.SongCollections)
                .HasForeignKey(sc => sc.Id_Song)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<SongCollection>()
                .HasOne(sc => sc.Collection)
                .WithMany(c => c.SongCollections)
                .HasForeignKey(sc => sc.Id_Collection)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.Id_Artist)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.Id_Album)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Genre)
                .WithMany(g => g.Songs) 
                .HasForeignKey(s => s.Id_Genre)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Album>()
                .HasOne(album => album.Genre)
                .WithMany(genre => genre.Albums)
                .HasForeignKey(album  => album.Id_Genre);
            modelBuilder.Entity<Album>()
                .HasOne(album => album.Artist)
                .WithMany(artist => artist.Albums)
                .HasForeignKey(album => album.Id_Artist);
        }
    }
}
