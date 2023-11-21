namespace Laboratorium3.Models
{
    public interface IContactService
    {
         void Add(Contact contact);
         void Update(Contact contact);
         void DeleteById(Contact contact);
         Contact? FindById(int id);
         List<Contact> FindAll();
         




    }
}
