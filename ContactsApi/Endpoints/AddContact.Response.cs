using System.ComponentModel;
using ContactsApi.Core.Models;

namespace ContactsApi.Endpoints
{
    public class AddContactResponse(Contact contact)
    {
        [property: Description("API response message")]
        public string Message { get; } = "Contact added successfully!";

        public Contact Contact { get; set; } = contact;
    }
}
