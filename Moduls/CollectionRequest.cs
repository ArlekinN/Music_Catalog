namespace ModulsDB
{
    // класс для запроса по созданию коллекции
    public class CollectionRequest
    {
        public string Title { get; set; }
        public int Epoch { get; set; }
        public Genre? Genre { get; set; }
    }
}
