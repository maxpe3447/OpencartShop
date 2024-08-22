using Microsoft.AspNetCore.Identity;

namespace Api.Storage.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<UserRole>? UserRoles { get; set; }
        public List<FavoriteProduct>? FavoriteProducts { get; set; }
        public List<CartItem>? CartItems { get; set; }
        public List<Order>? Orders { get; set; }
        public List<ReturnProduct>? ReturnProducts { get; set; }

    }
}
