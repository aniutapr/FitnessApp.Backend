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
		httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
		httpContext.Response.ContentType = "application.json";
		await httpContext.Response.WriteAsync(
			new ErrorDetails
			{
				StatusCode = httpContext.Response.StatusCode,
				Message = "InternalServerErrorFromCustomExMiddleware"
			}.ToString());
    }
}