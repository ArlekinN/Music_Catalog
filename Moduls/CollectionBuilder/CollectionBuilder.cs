
namespace ModulsDB
{
    // строитель для коллекции
    abstract public class CollectionBuilder
    {
        public Collection Collection { get; private set; }
        public void CreateCollection()
        {
            Collection = new Collection();
        }
        public abstract void SetTitle(string title, string titleGenre);
        public abstract void SetGender(int genre);
        public abstract void SetEpoch(int epoch);
    }
}
