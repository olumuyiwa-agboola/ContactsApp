using ContactsApi.Core.Abstractions;

namespace ContactsApi.Core.Result
{
    public class Result<T> : IResult
    {
        #region Constructors
        public Result(T value)
        {
            Error = null;
            Value = value;
            IsSuccess = true;
            Status = ResultStatus.Ok;
        }

        public Result(Error error)
        {
            Value = default;
            IsSuccess = false;
            Status = error.Type;
            Error = new Error()
            {
                Type = error.Type,
                Detail = error.Detail
            };
        }
        #endregion

        #region Implicit operators
        public static implicit operator Result<T>(T value) => new(value);

        public static implicit operator Result<T>(Error error) => new(error);
        #endregion

        #region Public properties
        public T? Value { get; set; }

        public Error? Error { get; set; }

        public bool IsSuccess { get; set; }

        public Type ValueType => typeof(T);

        public ResultStatus Status { get; set; }
        #endregion

        #region Public methods
        public object? GetValue() => Value;
        #endregion
    }
}