// New entity for the list of songs
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

// Updated AlbumEntity class
[Table("albums")]
public class AlbumEntity
{
    [Key]
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Zespol { get; set; }

    public string Spis_piosenek { get; set; }
    public int Notowanie { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime Data_wydania { get; set; } // data wydania

    public int Czas_trwania { get; set; } // 
}
