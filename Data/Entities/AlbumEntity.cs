using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{

    [Table("albums")]
    public class AlbumEntity
    {
       [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string? Zespol { get; set; }
        public List<string>? Spis_piosenek { get; set; }
        public int? Notowanie { get; set; }
        public DateTime? Data_wydania { get; set; }
       public List<TimeSpan>? Czas_trwania { get; set; }

    }




}
