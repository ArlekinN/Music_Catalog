using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Song
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int AlbumId { get; set; }
        public  Album Album { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        public int YearRelease { get; set; }
        public  ICollection<SongCollection> SongCollections { get; set; }

    }
}

