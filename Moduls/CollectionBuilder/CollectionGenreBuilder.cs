namespace ModulsDB
{
    // строитель для коллекции по жанру
    public class CollectionGenreBuilder:CollectionBuilder
    {
        public override void SetGender(int genre)
        {
            this.Collection.GenreId = genre;
        }
        public override void SetEpoch(int epoch)
        {

        }
        public override void SetTitle(string title, string titleGenre)
        {
            if (title == "")
            {
                this.Collection.Title = titleGenre;
            }
            else
            {
                this.Collection.Title = title;
            }
            
        }
    }
}
