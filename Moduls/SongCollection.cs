using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModulsDB
{
    public class SongCollection
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }

    }
}
