using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OpencartShop.Domain.Entities;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

namespace OpencartShop.Helpers
{
    public class AuthConfigs
    {
        private static PasswordHasher<User> _passwordHasher = new();
        public static string? AdminPassword { get; set; }
        public static string? ISSUER { get; set; }
        public static string? AUDIENCE { get; set; }
        public static string? KEY { get; set; }
        public static string? SALT { get; set; }
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
       new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY!));
        public static string GetAdminPasswordHash()
            => GetPasswordHash(AdminPassword!);
        public static string GetPasswordHash(string password)
        {
            // Generate a 128-bit salt using a sequence of
            // cryptographically strong random bytes.
            //byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: Convert.FromBase64String(SALT!),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
