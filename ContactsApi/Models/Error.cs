namespace ContactsApi.Models
{
    public class Error
    {
        public int status { get; set; } 
        public required string title { get; set; }
        public required string message { get; set; }
    }
}
