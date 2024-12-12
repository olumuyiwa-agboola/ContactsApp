using ContactsApi.Core.Models;

namespace ContactsApi.Core.Abstractions
{
    public interface IContactsRepository
    {
        public Task<Contact?> GetContact(string contactId);

        public Task<int> SaveContact(Contact contact);
    }
}
