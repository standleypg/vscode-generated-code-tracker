using System.Security.Cryptography;
using System.Text;
using Application.Common.Interfaces.Auth;

namespace Infrastructure.Auth;

public class PasswordHasher: IPasswordHasher
{
     public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }
}