using System.Text.Json;
using SSDB_Lab4.Common.Exceptions;

namespace SSDB_Lab4.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(
        RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        
        var code = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        response.ContentType = "application/json";
        response.StatusCode = code;

        var result = JsonSerializer.Serialize(
            new { message = exception.Message });

        return response.WriteAsync(result);
    }
}