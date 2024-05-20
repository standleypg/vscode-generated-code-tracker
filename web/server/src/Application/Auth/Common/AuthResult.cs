using Domain.Entities;

namespace Application.Auth.Common;

public record AuthResult(Domain.Entities.User User, string Token);