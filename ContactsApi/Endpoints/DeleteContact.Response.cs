using System.ComponentModel;

namespace ContactsApi.Endpoints
{
    public class DeleteContactResponse
    {
        [property: Description("API response message")]
        public string Message { get; } = "Contact deleted successfully!";
    }
}