using System.Threading;

namespace ModulsDB
{
    // создания коллекции в зависимости от типа
    public class DirectorCollection
    {
        public Collection Director(CollectionBuilder collectionBuilder,  int epoch, int genre, string titleGenre, string title="")
        {
            collectionBuilder.CreateCollection();
            collectionBuilder.SetGender(genre);
            collectionBuilder.SetEpoch(epoch);
            collectionBuilder.SetTitle(title, titleGenre);
            return collectionBuilder.Collection;
        }
    }
}
