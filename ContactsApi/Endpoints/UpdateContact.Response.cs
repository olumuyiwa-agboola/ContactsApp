using System.ComponentModel;
using ContactsApi.Core.Models;

namespace ContactsApi.Endpoints
{
    public class UpdateContactResponse(Contact contact)
    {
        [property: Description("API response message")]
        public string Message { get; } = "Contact updated successfully!";

        public Contact Contact { get; set; } = contact;
    }
}
