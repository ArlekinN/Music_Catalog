using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Genre
    {
        public int Id { get; init; }
        public string Title { get; init; }

        public Genre(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
