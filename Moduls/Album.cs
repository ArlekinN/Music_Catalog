using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Album
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public string Title { get; init; }
        [Required]
        public int YearRelease { get; init; }

        [Required]
        [ForeignKey("Genre")]
        public int Id_Genre { get; set; }
        public virtual Genre Genre { get; set; }

        [Required]
        [ForeignKey("Artist")]
        public int Id_Artist { get; set; }
        public virtual Artist Artist { get; set; }
        [InverseProperty("Album")]
        public HashSet<Song> Songs { get; } = new();

        public Album(int id, string title, int yearRelease,int id_genre,int id_artist)
        {
            Id = id;
            Title = title;
            YearRelease = yearRelease;
            Id_Genre = id_genre;
            Id_Artist = id_artist;
        }
        public Album() { }

    }
}
