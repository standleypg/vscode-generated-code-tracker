using Application.Auth.Common;
using MediatR;

namespace Application.Auth.Commands;

public record RegisterCommand(string Username, string Email, string Password) : IRequest<AuthResult>;