using ContactsApi.Core.Models;
using System.ComponentModel;

namespace ContactsApi.Endpoints
{
    public class GetContactByIdResponse(Contact contact)
    {
        [property: Description("API response message")]
        public string Message { get; } = "Contact retrieved successfully!";

        public Contact Contact { get; set; } = contact;
    }
}