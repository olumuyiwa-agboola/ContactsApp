using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Endpoints
{
    public class AddContactRequest(string firstName, string lastName, string email, string phoneNumber)
    {
        [property: Required]
        [property: Description("First name of the contact")]
        public string FirstName { get; set; } = firstName;

        [property: Required]
        [property: Description("Last name of the contact")]
        public string LastName { get; set; } = lastName;

        [property: Required]
        [property: Description("Email address of the contact")]
        public string Email { get; set; } = email;

        [property: Required]
        [property: Description("Phone number of the contact")]
        public string PhoneNumber { get; set; } = phoneNumber;
    }
}
