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
            Database.EnsureCreated();   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                    new Artist { Id = 1, Name = "AkaTommi" },
                    new Artist { Id = 2, Name = "SiniorPapa" },
                    new Artist { Id = 3, Name = "LightMusic" }
            );
            modelBuilder.Entity<SongCollection>()
                .HasKey(sc => new { sc.SongId, sc.CollectionId });

            modelBuilder.Entity<SongCollection>()
                .HasOne(sc => sc.Song)
                .WithMany(s => s.SongCollections)
                .HasForeignKey(sc => sc.SongId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<SongCollection>()
                .HasOne(sc => sc.Collection)
                .WithMany(c => c.SongCollections)
                .HasForeignKey(sc => sc.CollectionId)
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

        }
    }
}
