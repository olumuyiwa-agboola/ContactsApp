using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Endpoints
{
    public record UpdateContactRequest(
        [property: Required]
        [property: Description("Unique identifier assigned to the contact when the record was created")]
        string ContactId,

        [property: Required]
        [property: Description("First name of the contact")]
        string FirstName,

        [property: Required]
        [property: Description("Last name of the contact")]
        string LastName,

        [property: Required]
        [property: Description("Email address of the contact")]
        string Email,

        [property: Required]
        [property: Description("Phone number of the contact")]
        string PhoneNumber
    );
}
