using ModulsDB;
using Microsoft.EntityFrameworkCore;


namespace Music_Catalog
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongCollection> SongCollections { get; set; }
        public DbSet<TypeAlbum> TypeAlbums { get; set; }

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

            modelBuilder.Entity<Album>()
                .HasOne(a => a.TypeAlbum)
                .WithMany()
                .HasForeignKey(a => a.TypeAlbumId);

            modelBuilder.Entity<Artist>()
               .HasMany(a => a.TypeAlbums)
               .WithOne(a => a.Artist)
               .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<TypeAlbum>()
                .HasOne(a => a.Genre)
                .WithMany()
                .HasForeignKey(a => a.GenreId);
            

            modelBuilder.Entity<TypeAlbum>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.TypeAlbums)
                .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(ar => ar.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Genre)
                .WithMany()
                .HasForeignKey(s => s.GenreId);
            modelBuilder.Entity<Collection>()
               .HasOne(c => c.Genre)
               .WithMany()
               .HasForeignKey(c => c.GenreId);
        }
    }
}
