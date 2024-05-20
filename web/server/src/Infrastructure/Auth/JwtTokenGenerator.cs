using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _datetimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider datetimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _datetimeProvider = datetimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim(ClaimTypes.Name, user.UserName),
        };

        var security = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: _datetimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
            signingCredentials: signingCredentials

        );

        return new JwtSecurityTokenHandler().WriteToken(security);
    }
}