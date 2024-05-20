using Application.Auth.Common;
using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Auth.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(request.Username) is not null)
        {
            throw new Exception("Username already exists");
        }

        _passwordHasher.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

        var user = Domain.Entities.User.Create(
            request.Username,
            request.Email,
            passwordHash,
            passwordSalt
            );

        var addedUser = await _userRepository.AddUserAsync(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(addedUser, token);
    }
}
