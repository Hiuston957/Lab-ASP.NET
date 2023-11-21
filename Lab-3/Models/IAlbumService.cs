namespace Laboratorium3.Models
{
    public interface IAlbumService
    {
        void Add(Album album);
        void Update(Album album);
        void DeleteById(Album album);
        Album? FindById(int id);
        List<Album> FindAll();
    }
}
