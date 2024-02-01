namespace Laboratorium3.Models
{
    public class MemoryAlbumServices : IAlbumService
    {
        private readonly Dictionary<int, Album> _albums= new Dictionary<int, Album>()
        {

            //{ 1, new AlbumEntity() { Id = 1, Nazwa = "Nazwa1", Zespol = "Autor1", Spis_piosenek = "m1, m2, m3", Notowanie = 12, Data_wydania = new DateTime(2023, 11, 11) } },
          //  { 2, new AlbumEntity() { Id = 2, Nazwa = "Nazwa2", Zespol = "Autor2", Spis_piosenek = "muzyka1", Notowanie = 234, Data_wydania = new DateTime(2022, 12, 12) } }
 
         //  {1, new Album() {Id=1,Nazwa="Nazwa1",Zespol="Autor1",Spis_piosenek=new List<string> {"m1", "m2","m3" },Notowanie=12,Czas_trwania=new List<TimeSpan> { new TimeSpan(12,4,13), new TimeSpan(0,03,39), new TimeSpan(0,01,11) } , Data_wydania = new DateTime(2023,11,11)} },
         //   {2, new Album() {Id=2,Nazwa="Nazwa2",Zespol="Autor2",Spis_piosenek=new List<string> {"muzyka1"}, Notowanie=234,Czas_trwania=new List<TimeSpan> { new TimeSpan(33,55,24) } , Data_wydania = new DateTime(2022,12,12)}},
            



        };
        private int _id = 3;
        public void Add(Album album)
        {
            album.Id = _id++;
            _albums[album.Id] = album;
        }

        public void DeleteById(Album album)
        {
            _albums.Remove(album.Id);
        }

        public List<Album> FindAll()
        {
            return _albums.Values.OrderBy(album => album.Zespol).ToList();
        }

        public Album? FindById(int id)
        {
            return _albums[id];
        }

        public void Update(Album album)
        {
            _albums[album.Id] = album;
        }
    }
}

