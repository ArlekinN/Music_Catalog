namespace ModulsDB
{
    public class Album
    {
        private string id;
        public string Title { get; init; }
        public int YearRelease { get; init; }
        public Genre Genre { get; init; }
        public int ArtistId { get; init; }
        public List<Song> Songs { get; set; }

        public Album(string id, string title, int yearRelease, Genre genre, int artistId)
        {
            this.id = id;
            Title = title;
            YearRelease = yearRelease;
            Genre = genre;
            Songs = new List<Song>();
            ArtistId = artistId;
        }
    }
}
