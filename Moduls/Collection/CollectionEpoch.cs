namespace ModulsDB
{
    public class CollectionEpoch : Collection
    {
        public int Epoch { get; init; }
        public CollectionEpoch(string id, string title, int epoch) : base(id, title, TypeCollection.Epoch)
        {
            Epoch = epoch;
        }
    }
}

