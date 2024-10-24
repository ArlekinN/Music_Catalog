using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Song
    {
        [Key]
        private int Id;
        [Required]
        public string Title { get; init; }
        [ForeignKey("Artist")]
        [Required]
        public int id_Artist;
        public virtual Artist Artist { get; set; }
        [Required]
        [ForeignKey("Album")]
        public int id_Album;
        public virtual Album Album { get; set; }
        [ForeignKey("Genre")]
        [Required]
        public int id_Genre;
        public virtual Genre Genre { get; set; }
        [Required]
        public float Duration { get; init; }
        [Required]
        public int YearRelease { get; init; }
        [InverseProperty("Song")]
        public HashSet<Collection> Collections { get; } = new();

        public Song(int id, string title,int id_artist, int id_album, float duration, int yearRelease, int id_genre)
        {
            Id = id;
            Title = title;
            id_Artist = id_artist;
            id_Album = id_album;
            Duration = duration;
            YearRelease = yearRelease;
            id_Genre = id_genre;
        }
    }
}

