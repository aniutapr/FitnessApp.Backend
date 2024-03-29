using System.Net;
using FitnessApp.Contracts.Interfaces.Services;
using FitnessApp.Domain.CustomExceptions;

namespace FitnessApp.Api.Middleware;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILoggerManager _logger;
	public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
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

        if (ex is UnauthorizedAccessException)
        {
            statusCode = HttpStatusCode.Forbidden;
            message = "Unauthorized access exception";
        }
        else if (ex is FileNotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
            message = "File not found exception";
        }
        else if (ex is ArgumentException)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = "Bad request exception";
        }

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