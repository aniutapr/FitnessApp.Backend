using System.Net;
using FitnessApp.Domain.CustomExceptions;

namespace FitnessApp.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await _next(httpContext);
		}
		catch(Exception ex)
		{
			_logger.LogError("Something went wrong");
			await HandleExceptionAsync(httpContext, ex);
		}
	}

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "Internal Server Error";

        switch (ex)
        {
            case UnauthorizedAccessException _:
                statusCode = HttpStatusCode.Forbidden;
                message = "Unauthorized access exception";
                break;
            case FileNotFoundException _:
                statusCode = HttpStatusCode.NotFound;
                message = "File not found exception";
                break;
            case ArgumentException _:
                statusCode = HttpStatusCode.BadRequest;
                message = "Bad request exception";
                break;
        }

        _logger.LogError($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");

        httpContext.Response.StatusCode = (int)statusCode;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(
            new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
    }

}