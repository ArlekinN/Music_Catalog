namespace ModulsDB
{
    // строитель для коллекции по эпохе
    public class CollectionEpochBuilder : CollectionBuilder
    {
        public override void SetGender(int genre)
        {
           
        }
        public override void SetEpoch(int epoch)
        {
            this.Collection.Epoch = epoch;
        }
        public override void SetTitle(string title, string titleGenre)
        {
            if (title == "")
            {
                var newtitle = this.Collection.Epoch.ToString();
                newtitle = newtitle + "x";
                this.Collection.Title = newtitle;
            }
            else
            {
                this.Collection.Title = title;
            }
            
        }
    }
}
