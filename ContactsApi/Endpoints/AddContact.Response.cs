using ContactsApi.Core.Models;

namespace ContactsApi.Endpoints
{
    public class AddContactResponse(Contact contact)
    {
        public string Message { get; } = "Contact added successfully!";

        public Contact Contact { get; set; } = contact;
    }
}
