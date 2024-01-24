// New entity for the list of songs
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("album_songs")]
public class AlbumSong
{
    [Key]
    public int Id { get; set; }
    public string SongTitle { get; set; }

    // Foreign key to link with AlbumEntity
    public int AlbumId { get; set; }
    public AlbumEntity Album { get; set; }
}

[Table("album_timespans")]
public class AlbumTimeSpan
{
    [Key]
    public int Id { get; set; }
    public TimeSpan TimeSpanValue { get; set; }

    // Foreign key to link with AlbumEntity
    public int AlbumId { get; set; }
    public AlbumEntity Album { get; set; }
}


// Updated AlbumEntity class
[Table("albums")]
public class AlbumEntity
{
    [Key]
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Zespol { get; set; }

    // Remove List<string> Spis_piosenek
    public int Notowanie { get; set; }
    public DateTime Data_wydania { get; set; }

    // Navigation property to link with AlbumSong
    public List<AlbumSong> Songs { get; set; }

    // Other properties...

    // Navigation property to link with AlbumTimeSpan
    public List<AlbumTimeSpan> Czas_trwania { get; set; }
}
