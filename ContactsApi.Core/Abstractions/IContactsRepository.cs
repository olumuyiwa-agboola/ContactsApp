using ContactsApi.Core.Models;

namespace ContactsApi.Core.Abstractions
{
    public interface IContactsRepository
    {
        Task<List<Contact>> GetAllContacts();

        Task<int> SaveContact(Contact contact);

        Task<int> UpdateContact(Contact contact);

        Task<int> DeleteContact(string contactId);

        Task<Contact?> GetContact(string contactId);
    }
}
