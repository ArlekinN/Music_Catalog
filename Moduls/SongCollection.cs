using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class SongCollection
    {
        [ForeignKey("Song")]
        [Required]
        public int Id_Song { get; set; }
        public virtual Song Song { get; set; }
        [ForeignKey("Collection")]
        [Required]
        public int Id_Collection { get; set; }
        public virtual Collection Collection { get; set; }
        public SongCollection(int id_Song, int id_Collection){
            Id_Song = id_Song;
            Id_Collection = id_Collection;
        }
        public SongCollection() { }

    }
}
