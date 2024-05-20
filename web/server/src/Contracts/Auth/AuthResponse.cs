namespace Contracts.Auth;

public record AuthResponse(Guid Id, string Username, string Token, string Email);
