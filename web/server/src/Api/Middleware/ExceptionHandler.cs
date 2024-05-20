using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Api.Middleware;

public class ExceptionHandler: IExceptionHandler
{
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var result = new ValidationProblemDetails();
        switch (exception)
        {
            case ArgumentNullException argumentNullException:
                result = new ValidationProblemDetails
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Type = argumentNullException.GetType().Name,
                    Title = "An unexpected error occurred",
                    Detail = argumentNullException.Message,
                    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                };
                break;
            case ValidationException validationException:
                result = new ValidationProblemDetails
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Type = validationException.GetType().Name,
                    Title = "An unexpected error occurred",
                    Detail = "Refer to the errors property for additional details",
                    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                    Errors = validationException.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(
                            x => x.Key,
                            x => x.Select(y => y.ErrorMessage).ToArray()
                        )
                };
                break;
            default:
                result = new ValidationProblemDetails
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Type = exception.GetType().Name,
                    Title = "An unexpected error occurred",
                    Detail = exception.Message,
                    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                };
                break;
        }
        await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);
        return true;
    }
}