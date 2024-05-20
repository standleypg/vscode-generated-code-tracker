using Application.Auth.Common;
using MediatR;

namespace Application.Auth.Queries;

public record LoginQuery(string Email, string Password) : IRequest<AuthResult>;