using ContactsApi.Core.Models;

namespace ContactsApi.Endpoints
{
    public class GetAllContactsResponse(List<Contact> contacts)
    {
        public List<Contact> Contacts { get; set; } = contacts;

        public string Message { get; set; } = "Contacts retrived successfully!";
    }
}
