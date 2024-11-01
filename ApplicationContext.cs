using ModulsDB;
using Microsoft.EntityFrameworkCore;


namespace Music_Catalog
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; } 
        public DbSet<Genre> Genres { get; set; } 
        public DbSet<Album> Albums { get; set; }
        public DbSet<Collection> Collections{ get; set; }
        public DbSet<Song> Songs { get; set; } 
        public DbSet<SongCollection> SongCollection { get; set; } 
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongCollection>()
                .HasKey(pc => new { pc.SongId, pc.CollectionId });
            modelBuilder.Entity<SongCollection>()
                .HasOne(p => p.Song)
                .WithMany(pc => pc.SongCollections)
                .HasForeignKey(c => c.SongId);
            modelBuilder.Entity<SongCollection>()
                .HasOne(p => p.Collection)
                .WithMany(pc => pc.SongCollections)
                .HasForeignKey(c => c.CollectionId);

           

            modelBuilder.Entity<Artist>()
               .HasMany(a => a.Albums)
               .WithOne(a => a.Artist)
               .HasForeignKey(a => a.ArtistId);


            // Настройка связи между Genre и Album
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Genre)
                .WithMany()
                .HasForeignKey(a => a.GenreId);

            // Настройка связи между Artist и Album
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId);



            // Настройка связи между Album и Song
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);

            // Настройка связи между Artist и Song
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(ar => ar.Songs)
                .HasForeignKey(s => s.ArtistId);

            // Настройка связи между Genre и Song
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Genre)
                .WithMany()
                .HasForeignKey(s => s.GenreId);


        }  
    }
}
