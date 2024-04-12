namespace ContactsApi.Models
{
    public class DeleteContactResponse
    {
        public int? ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public Contact? DeletedContact { get; set; }
    }
}
