namespace ModulsDB
{
    public enum Genre
    {
        Rock,
        Pop
    }
    public class Song
    {
        private string id;
        public string Title { get; init; }
        public int ArtistId { get; init; }

        public float Duration { get; init; }
        public int YearRelease { get; init; }
        public Genre Genre { get; init; }

        public Song(string id, string title, int artistId, float duration, int yearRelease, Genre genre)
        {
            this.id = id;
            Title = title;
            ArtistId = artistId;
            Duration = duration;
            YearRelease = yearRelease;
            Genre = genre;
        }
    }
}

