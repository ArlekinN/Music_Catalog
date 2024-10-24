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
        private int Id { get; init; }
        [Required]
        public string Title { get; init; }
        [Required]
        public TypeCollection TypeCollection { get; init; }
        [ForeignKey("Genre")]
        public int? id_Genre;
        public virtual Genre Genre { get; set; }
        public int? YearRelease { get; init; }
        [InverseProperty("Collection")]
        public HashSet<Song> Songs { get; } = new();
        public Collection(int id, string title, TypeCollection typeCollection, int parametrOfTypeCollection)
        {
            Id = id;
            Title = title;
            TypeCollection = typeCollection;
            if(typeCollection== TypeCollection.Genre)
            {
                id_Genre = parametrOfTypeCollection;
                YearRelease = null;
            }
            else
            {
                YearRelease = parametrOfTypeCollection;
                id_Genre = null;
            } 
        }
    }
}