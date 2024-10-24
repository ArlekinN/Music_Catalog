using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Genre
    {
        public int Id { get; init; }
        public string Title { get; init; }
        [InverseProperty("Genre")]
        public virtual HashSet<Song> Songs { get; } = new();
        [InverseProperty("Genre")]
        public virtual HashSet<Album> Albums { get; } = new();
        [InverseProperty("Genre")]
        public virtual HashSet<Collection> Collections { get; } = new();

        public Genre(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public Genre() { }
    }
}
