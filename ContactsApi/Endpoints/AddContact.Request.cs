namespace ContactsApi.Endpoints
{
    public class AddContactRequest(string firstName, string lastName, string email, string phoneNumber)
    {
        public string? FirstName { get; set; } = firstName;

        public string? LastName { get; set; } = lastName;

        public string? Email { get; set; } = email;

        public string? PhoneNumber { get; set; } = phoneNumber;
    }
}
