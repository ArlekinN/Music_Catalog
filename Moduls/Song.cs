using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Song
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public string Title { get; init; }
        [ForeignKey("Artist")]
        [Required]
        public int Id_Artist;
        public virtual Artist Artist { get; set; }
        [Required]
        [ForeignKey("Album")]
        public int Id_Album { get; set; }
        public virtual Album Album { get; set; }
        [ForeignKey("Genre")]
        [Required]
        public int Id_Genre { get; set; }
        public virtual Genre Genre { get; set; }
        [Required]
        public float Duration { get; init; }
        [Required]
        public int YearRelease { get; init; }
        [InverseProperty("Song")]
        public virtual HashSet<SongCollection> SongCollections { get; } = new();

        public Song(int id, string title,int id_artist, int id_album, float duration, int yearRelease, int id_genre)
        {
            Id = id;
            Title = title;
            Id_Artist = id_artist;
            Id_Album = id_album;
            Duration = duration;
            YearRelease = yearRelease;
            Id_Genre = id_genre;
        }
        public Song() { }
    }
}

