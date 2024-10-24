using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Artist
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public string Name { get; init; } = "";
        [InverseProperty("Artist")]
        public HashSet<Album> Albums { get; } = new();
        [InverseProperty("Artist")]
        public HashSet<Song> Songs { get; } = new();
        public Artist(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Artist() { }
    }
}