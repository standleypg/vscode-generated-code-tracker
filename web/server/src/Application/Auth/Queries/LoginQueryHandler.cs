using Application.Auth.Common;
using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Persistence;
using MediatR;

namespace Application.Auth.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is null) throw new Exception("User not found");

        if (!_passwordHasher.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            throw new UnauthorizedAccessException("Invalid password");
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }
}