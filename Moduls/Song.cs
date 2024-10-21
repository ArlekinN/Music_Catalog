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
        public Artist Artist { get; init; }
        public Album Album { get; init; }

        public float Duration { get; init; }
        public int YearRelease { get; init; }
        public Genre Genre { get; init; }

        public Song(string id, string title, Artist artist, Album album, float duration, int yearRelease, Genre genre)
        {
            this.id = id;
            Title = title;
            Artist = artist;
            Album = album;
            Duration = duration;
            YearRelease = yearRelease;
            Genre = genre;
        }
    }
}

