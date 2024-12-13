using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Core.Models
{
    public class Contact
    {
        [property: Required]
        [property: Description("Unique identifier assigned to the contact when the record was created")]
        public required string Id { get; set; }

        [property: Required]
        [property: Description("First name of the contact")]
        public required string FirstName { get; set; }

        [property: Required]
        [property: Description("Last name of the contact")]
        public required string LastName { get; set; }

        [property: Required]
        [property: Description("Email address of the contact")]
        public required string Email { get; set; }

        [property: Required]
        [property: Description("Phone number of the contact")]
        public required string PhoneNumber { get; set; }
    }
}
