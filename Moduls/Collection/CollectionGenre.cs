namespace ModulsDB
{
    public class CollectionGenre : Collection
    {
        public Genre Genre { get; init; }
        public CollectionGenre(string id, string title, Genre genre) : base(id, title, TypeCollection.Genre)
        {
            Genre = genre;
        }
    }
}
