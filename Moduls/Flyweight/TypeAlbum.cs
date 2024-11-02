

using ModulsDB;

namespace ModulsDB
{
    public class TypeAlbum
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

    }
}

