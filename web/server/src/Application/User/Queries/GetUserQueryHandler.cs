using Application.Common.Interfaces.Persistence;
using MediatR;

namespace Application.User.Queries;

public class GetUserQueryHandler: IRequestHandler<GetUserQuery, GetUserResult>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        return new GetUserResult(user);
    }
}