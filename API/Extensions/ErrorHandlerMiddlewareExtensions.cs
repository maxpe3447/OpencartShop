using Api.Middlewares;

namespace API.Extensions;

public static class ErrorHandlerMiddlewareExtensions
{
    public static void UseErrorHandler(this WebApplication application) =>
        application.UseMiddleware<ErrorHandlerMiddleware>();
}
