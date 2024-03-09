using System.Text.Json;

namespace Api.ErrorHandling;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
	private readonly RequestDelegate _next = next;

	private readonly ILogger<ExceptionMiddleware> _logger = logger;

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Unhandled exception.");
			if (context.Response.HasStarted)
			{
				_logger.LogWarning("Could not write error response. Response was already initiated.");
				return;
			}

			var errorDetail = HandleError(ex);

			context.Response.StatusCode = errorDetail.ErrorCode;
			context.Response.ContentType = "application/json";
			var text = JsonSerializer.Serialize(errorDetail);
			await context.Response.WriteAsync(text);
		}
	}

	private static ErrorDetail HandleError(Exception exception)
	{
		return exception switch
		{
			_ => new ErrorDetail
			{
				ErrorCode = 500,
			},
		};
	}
}
