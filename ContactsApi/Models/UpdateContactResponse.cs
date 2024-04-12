namespace ContactsApi.Models
{
    public class UpdateContactResponse
    {
        public int? ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public Contact? UpdatedContact { get; set; }
    }
}
