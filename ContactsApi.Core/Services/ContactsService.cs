using Ardalis.Result;
using ContactsApi.Core.Models;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Core.Services
{
    public class ContactsService(IContactsRepository _contactsRepository) : IContactsService
    {
        public async Task<Result<Contact>> AddContact(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            Contact contact = new() 
            {
                LastName = lastName,
                Email = emailAddress,
                FirstName = firstName,
                PhoneNumber = phoneNumber,
                Id = new Random().Next(10000, 100000).ToString()
            };

            int result = await _contactsRepository.SaveContact(contact);

            if (result == 1)
                return contact;
            else
                return Result.Error();
        }

        public async Task<Result<List<Contact>>> GetAllContacts()
        {
            List<Contact>? contacts = await _contactsRepository.GetAllContacts();

            if (contacts is not null && contacts.Count != 0)
                return contacts;
            else
                return Result.NotFound("There are no contacts in the database");
        }

        public async Task<Result<Contact>> GetContactById(string contactId)
        {
            Contact? contact = await _contactsRepository.GetContact(contactId);

            if (contact is not null)
                return contact;
            else
                return Result.NotFound("Contact not found");
        }
    }
}