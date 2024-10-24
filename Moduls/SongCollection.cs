using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulsDB
{
    public class SongCollection
    {
        [ForeignKey("Song")]
        [Required]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        [ForeignKey("Collection")]
        [Required]
        public int CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
