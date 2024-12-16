using ContactsApi.Core.Models;
using ContactsApi.Core.Result;

namespace ContactsApi.Core.Abstractions
{
    public interface IContactsService
    {
        Task<Result<List<Contact>>> GetAllContacts();

        Task<Result<string>> DeleteContact(string contactId);

        Task<Result<Contact>> GetContactById(string contactId);

        Task<Result<Contact>> AddContact(string firstName, string lastName, string emailAddress, string phoneNumber);

        Task<Result<Contact>> UpdateContact(string contactId, string firstName, string lastName, string emailAddress, string phoneNumber);
    }
}
