using System.Net;
using FastEndpoints;
using ContactsApi.Core.Result;
using IResult = ContactsApi.Core.Result.IResult;

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
                    await endpoint.HttpContext.Response.SendAsync(
                        new ProblemDetails()
                        {
                            Detail = result.Error!.Detail,
                            Status = (int)HttpStatusCode.NotFound,
                            TraceId = endpoint.HttpContext.TraceIdentifier,
                            Instance = endpoint.HttpContext.Request.Path.Value!
                        }, (int)HttpStatusCode.NotFound);
                    break;

                case ResultStatus.UnprocessableEntity:
                    await endpoint.HttpContext.Response.SendAsync(
                        new ProblemDetails()
                        {
                            Detail = result.Error!.Detail,
                            Status = (int)HttpStatusCode.UnprocessableEntity,
                            TraceId = endpoint.HttpContext.TraceIdentifier,
                            Instance = endpoint.HttpContext.Request.Path.Value!
                        }, (int)HttpStatusCode.UnprocessableEntity);
                    break;
            }
        }
    }
}
