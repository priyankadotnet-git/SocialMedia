using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SocialMedia.Extensions
{
    public static class CheckPassword
    {
        public static string HashPassword(this string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password);
        }
        public static bool VerifyPassword(this string Password, string Hashed)
        {
            return BCrypt.Net.BCrypt.Verify(Password, Hashed);
        }

    }
}
