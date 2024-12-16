namespace ContactsApi.Core.Result
{
    public class Error
    {
        public ResultStatus Type { get; set; }

        public required string Detail { get; set; }
    }
}
