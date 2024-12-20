namespace ContactsApi.Core.Result
{
    public class Error
    {
        public ResultStatus Type { get; set; }

        public required string Detail { get; set; }
    }

    public class ErrorResult
    {
        public static Error NotFound() => new() { Type = ResultStatus.NotFound, Detail = "Record not found" };

        public static Error NotFound(string message) => new() { Type = ResultStatus.NotFound, Detail = message };

        public static Error UnprocessableEntity(string message) => new() { Type = ResultStatus.UnprocessableEntity, Detail = message };

        public static Error UnprocessableEntity() => new() { Type = ResultStatus.UnprocessableEntity, Detail = "An unprocessable entity was passed" };
    }
}
