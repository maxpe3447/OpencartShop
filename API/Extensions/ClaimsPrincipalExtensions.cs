using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        int.TryParse(user.FindFirst("userId")!.Value, out int userId);
        return userId;
    }
}
