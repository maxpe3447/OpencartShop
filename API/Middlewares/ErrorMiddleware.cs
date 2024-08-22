using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace Api.Middlewares
{

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            ProblemDetailsFactory problemDetailsFactory,
            ILogger<ErrorHandlerMiddleware> logger)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception,
                    "Error has happened with {RequestPath}, the message is {ErrorMessage}",
                    context.Request.Path.Value, exception.Message);


                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                //await context.Response.WriteAsJsonAsync<ProblemDetails>(problemDetails);
                context.Response.Headers.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(exception));
            }
        }
    }
}