using Data.Entities;
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
                Spis_piosenek = entity.Spis_piosenek,
                Notowanie = entity.Notowanie,
                Data_wydania = entity.Data_wydania,
                Czas_trwania = entity.Czas_trwania,
            };
        }

        public static AlbumEntity ToEntity(Album model)
        {
            return new AlbumEntity()
            {
                Id = model.Id,
                Nazwa = model.Nazwa,
                Zespol = model.Zespol,
                Spis_piosenek = model.Spis_piosenek,
                Notowanie = model.Notowanie,
                Data_wydania = model.Data_wydania,
                Czas_trwania = model.Czas_trwania,
            };
        }
    }
}

