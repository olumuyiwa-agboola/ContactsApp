using ContactsApi.Core.Models;

namespace ContactsApi.Endpoints
{
    public class GetContactByIdResponse(Contact contact)
    {
        public string Message { get; } = "Contact retrieved successfully!";

        public Contact Contact { get; set; } = contact;
    }
}