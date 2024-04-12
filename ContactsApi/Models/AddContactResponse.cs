namespace ContactsApi.Models
{
    public class AddContactResponse
    {
        public int? ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public Contact? NewContact { get; set; }
    }
}
