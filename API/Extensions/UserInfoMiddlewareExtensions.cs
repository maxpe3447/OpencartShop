using API.Middlewares;

namespace API.Extensions
{
    public static class UserInfoMiddlewareExtensions
    {
        public static void UseUserInfoHandler(this WebApplication application) =>
            application.UseMiddleware<UserInfoMiddleware>();
    }
}
