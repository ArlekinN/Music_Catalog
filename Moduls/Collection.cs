using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace ModulsDB
{
    public enum TypeCollection
    {
        Genre,
        Epoch
    }
    public class Collection
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public string Title { get; init; }
        [Required]
        public TypeCollection TypeCollection { get; init; }
        [ForeignKey("Genre")]
        public int? Id_Genre { get; set; }
        public virtual Genre Genre { get; set; }
        public int? YearRelease { get; init; }
        [InverseProperty("Collection")]
        public HashSet<SongCollection> SongCollections { get; } = new();
        public Collection(int id, string title, TypeCollection typeCollection, int parametrOfTypeCollection)
        {
            Id = id;
            Title = title;
            TypeCollection = typeCollection;
            if(typeCollection== TypeCollection.Genre)
            {
                Id_Genre = parametrOfTypeCollection;
                YearRelease = null;
            }
            else
            {
                YearRelease = parametrOfTypeCollection;
                Id_Genre = null;
            } 
        }
        public Collection() { }
    }
}