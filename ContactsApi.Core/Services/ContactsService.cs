using Ardalis.Result;
using ContactsApi.Core.Models;
using ContactsApi.Core.Abstractions;

namespace ContactsApi.Core.Services
{
    public class ContactsService(IContactsRepository _contactsRepository) : IContactsService
    {
        public async Task<Result<Contact>> AddContact(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            string id = new Random().Next(10000, 100000).ToString();

            Contact contact = new(id, firstName, lastName, emailAddress, phoneNumber);

            int result = await _contactsRepository.SaveContact(contact);

            if (result == 1)
                return contact;
            else
                return Result.Error();
        }

        public async Task<Result<string>> DeleteContact(string contactId)
        {
            int? result = await _contactsRepository.DeleteContact(contactId);

            if (result == 1)
                return Result.Success();
            else if (result == 0)
                return Result.NotFound("Contact not found");
            else
                return Result.Error("An error occured");
        }

        public async Task<Result<List<Contact>>> GetAllContacts()
        {
            List<Contact>? contacts = await _contactsRepository.GetAllContacts();

            if (contacts is not null)
                return contacts;
            else
                return Result.NotFound("No contacts found");
        }

        public async Task<Result<Contact>> GetContactById(string contactId)
        {
            Contact? contact = await _contactsRepository.GetContact(contactId);

            if (contact is not null)
                return contact;
            else
                return Result.NotFound("Contact not found");
        }

        public async Task<Result<Contact>> UpdateContact(string contactId, string newFirstName, string newLastName, string newEmailAddress, string newPhoneNumber)
        {
            Contact? contact = await _contactsRepository.GetContact(contactId);

            if (contact is not null)
            {
                Contact updatedContact = new(contactId, newFirstName, newLastName, newEmailAddress, newPhoneNumber);

                var result = await _contactsRepository.UpdateContact(updatedContact);

                if (result == 1)
                    return updatedContact;
                else
                    return Result.Error();
            }
            else
                return Result.NotFound("Contact not found");
        }
    }
}