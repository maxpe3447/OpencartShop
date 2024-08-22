using Microsoft.AspNetCore.Identity;

namespace Api.Storage.Entities;

public class Role : IdentityRole<int>
{
    public ICollection<UserRole>? UserRoles { get; set; }
}
