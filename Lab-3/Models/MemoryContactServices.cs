using Data.Entities;

namespace Laboratorium3.Models
{
    public class MemoryContactServices : IContactService
    {
        private readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>()
        {
            {1,new Contact() {Id=1,Name="Jan",Email="test@mail.pl",Phone="111662222" } },
            {2,new Contact() {Id=2,Name="Szymon",Email="testowy@mail.pl",Phone="1232323" } },
        };
        private int _id = 3;

        public void Add(Contact contact)
        {
            contact.Id = _id++;
            _contacts[contact.Id] = contact;
        }

        public void DeleteById(Contact contact)
        {
            _contacts.Remove(contact.Id);
        }

        public List<Contact> FindAll()
        {
            return _contacts.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _contacts.TryGetValue(id, out var contact) ? contact : null;
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }

        public List<OrganizationEntity> FindAllOrganizationsForVieModel()
        {
 
            return new List<OrganizationEntity>();
        }
    }
}
