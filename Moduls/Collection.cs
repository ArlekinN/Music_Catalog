
namespace ModulsDB
{
    public class Collection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Epoch { get; set; } = null;
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; } = null;
        public ICollection<SongCollection> SongCollections { get; set; }
        
    }
}