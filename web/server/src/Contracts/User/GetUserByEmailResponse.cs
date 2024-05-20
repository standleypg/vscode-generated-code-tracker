namespace Contracts.User;

public record GetUserByEmailResponse(string Email, string Username, Guid Id);
