using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Endpoints
{
    public class GetContactByIdRequest(string contactId)
    {
        [property: Required]
        [property: Description("Unique identifier assigned to the contact when the record was created")]
        public required string ContactId { get; set; } = contactId;
    }
}
