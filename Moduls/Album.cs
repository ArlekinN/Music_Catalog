using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearRelease { get; set; }
        public int GenreId { get; set; }
        public  Genre Genre { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; } 

    }
}
