namespace ModulsDB
{
    public enum TypeCollection
    {
        Genre,
        Epoch
    }

    abstract public class Collection
    {
        private string id;
        public string Title { get; init; }
        public TypeCollection TypeCollection { get; init; }
        public List<Song> Songs { get; set; }
        public Collection(string id, string title, TypeCollection typeCollection)
        {
            this.id = id;
            Title = title;
            TypeCollection = typeCollection;
            Songs = new List<Song> { };
        }
    }
}