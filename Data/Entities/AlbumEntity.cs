using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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

[Table("albums")]
public class AlbumEntity
{
    [Key]
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string? Zespol { get; set; }
    //public List<string>? Spis_piosenek { get; set; }
    public int? Notowanie { get; set; }
    public DateTime? Data_wydania { get; set; }

    // Navigation property to link with AlbumTimeSpan
    public List<AlbumTimeSpan>? Czas_trwania { get; set; }
}
