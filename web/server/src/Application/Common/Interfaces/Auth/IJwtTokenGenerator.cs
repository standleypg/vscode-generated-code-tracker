using Domain.Entities;

namespace Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(Domain.Entities.User user);
}