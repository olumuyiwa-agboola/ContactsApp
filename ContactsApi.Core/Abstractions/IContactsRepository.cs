using Ardalis.Result;
using ContactsApi.Core.Models;

namespace ContactsApi.Core.Abstractions
{
    public interface IContactsRepository
    {
        Task<int> SaveContact(Contact contact);

        Task<Contact?> GetContact(string contactId);

        Task<List<Contact>> GetAllContacts();
    }
}
