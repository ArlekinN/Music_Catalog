namespace ModulsDB
{
    public class Artist
    {
        private string id;
        public string Name { get; init; }
        public List<Album> Albums { get; set; }

        public Artist(string id, string name)
        {
            this.id = id;
            Name = name;
            Albums = new List<Album> { };
        }
    }
}