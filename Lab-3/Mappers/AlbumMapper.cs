// Assuming this class is in the Mappers directory of your project
using Laboratorium3.Models;

namespace Laboratorium3.Mappers
{
    public class AlbumMapper
    {
        public static Album FromEntity(AlbumEntity entity)
        {
            return new Album()
            {
                Id = entity.Id,
                Nazwa = entity.Nazwa,
                Zespol = entity.Zespol,
                Notowanie = entity.Notowanie,
                Data_wydania = entity.Data_wydania,
                // Map other properties as needed

                // Map songs
                Spis_piosenek = entity.Songs?.Select(song => song.SongTitle).ToList(),

                // Map time spans
                Czas_trwania = entity.Czas_trwania?.Select(timeSpan => timeSpan.TimeSpanValue).ToList()
            };
        }

        public static AlbumEntity ToEntity(Album model)
        {
            return new AlbumEntity()
            {
                Id = model.Id,
                Nazwa = model.Nazwa,
                Zespol = model.Zespol,
                Notowanie = model.Notowanie,
                Data_wydania = model.Data_wydania,
                // Map other properties as needed

                // Map songs
                Songs = model.Spis_piosenek?.Select(songTitle => new AlbumSong { SongTitle = songTitle }).ToList(),

                // Map time spans
                Czas_trwania = model.Czas_trwania?.Select(timeSpan => new AlbumTimeSpan { TimeSpanValue = timeSpan }).ToList()
            };
        }
    }
}
