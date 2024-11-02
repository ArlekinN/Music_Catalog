
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearRelease { get; set; }
        public int TypeAlbumId { get; set; }
        public TypeAlbum TypeAlbum { get; set; }

        public ICollection<Song> Songs { get; set; } 


    }
}
