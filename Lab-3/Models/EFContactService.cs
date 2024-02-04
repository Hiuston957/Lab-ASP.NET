using Data;
using Data.Entities;
using Laboratorium3.Mappers;
using Laboratorium3.Models;

namespace Laboratorium3.Models
{
    public class EFContactService : IContactService
    {
        private AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Contact contact)
        {
            var entity = ContactMapper.ToEntity(contact);
            _context.Contacts.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            var entity = ContactMapper.ToEntity(contact);
            _context.Contacts.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteById(Contact contact)
        {
            var entity = ContactMapper.ToEntity(contact);
            _context.Contacts.Remove(entity);
            _context.SaveChanges();
        }

        public Contact? FindById(int id)
        {
            var entity = _context.Contacts.Find(id);
            return entity != null ? ContactMapper.FromEntity(entity) : null;
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public List<OrganizationEntity> FindAllOrganizationsForVieModel()
        {
            return _context.Organizations.ToList();
        }


    }
}
