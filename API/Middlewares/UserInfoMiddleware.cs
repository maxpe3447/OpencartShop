
using Api.Service.UserDataService;
using API.Extensions;

namespace API.Middlewares;

public class UserInfoMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate next = next;

    public async Task InvokeAsync(HttpContext context, IUserDataService userDataService)
    {
        userDataService.SetUserId(context.User.GetUserId());

        await next.Invoke(context);
    }
}
