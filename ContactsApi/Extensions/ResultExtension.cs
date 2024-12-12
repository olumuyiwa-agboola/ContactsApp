using Ardalis.Result;
using FastEndpoints;
using System.Net;

//using FastEndpoints.Swagger;
using IResult = Ardalis.Result.IResult;

namespace ContactsApi.Extensions
{
    public static class ResultExtension
    {
        public static async Task SendResponse<TResult, TResponse>(this IEndpoint endpoint, TResult result, Func<TResult, TResponse> mapper) where TResult : IResult
        {
            switch (result.Status)
            {
                case ResultStatus.Ok:
                    await endpoint.HttpContext.Response.SendAsync(mapper(result));
                    break;

                case ResultStatus.NotFound:
                    var problemDetails = new ProblemDetails()
                    {
                        Status = (int)HttpStatusCode.NotFound,
                        Detail = result.Errors.FirstOrDefault(),
                        TraceId = endpoint.HttpContext.TraceIdentifier,
                        Instance = endpoint.HttpContext.Request.Path.Value!
                    };

                    await endpoint.HttpContext.Response.SendAsync(problemDetails, (int)HttpStatusCode.NotFound);
                    break;
            }
        }
    }
}
