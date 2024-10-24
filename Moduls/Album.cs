using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Album
    {
        [Key]
        private int Id { get; init; }
        [Required]
        public string Title { get; init; }
        [Required]
        public int YearRelease { get; init; }
        [Required]
        [ForeignKey("Genre")]
        public int id_Genre;
        public virtual Genre Genre { get; set; }
        [Required]
        [ForeignKey("Artist")]
        public int id_Artist;
        public virtual Artist Artist { get; set; }
        [InverseProperty("Album")]
        public HashSet<Song> Songs { get; } = new();

        public Album(int id, string title, int yearRelease,int id_genre,int id_artist)
        {
            Id = id;
            Title = title;
            YearRelease = yearRelease;
            id_Genre = id_genre;
            id_Artist = id_artist;
        }
    }
}
