namespace ContactsApi.Core.Result
{
    public interface IResult
    {
        object? GetValue();

        Type ValueType { get; }

        Error? Error { get; set; }

        bool IsSuccess { get; set; }

        ResultStatus Status { get; set; }
    }
}
