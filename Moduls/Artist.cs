using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class Artist
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; } 
        public ICollection<Song> Songs { get; set; }

        public static implicit operator Artist(List<Artist> v)
        {
            throw new NotImplementedException();
        }
    }
}