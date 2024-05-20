using MediatR;

namespace Application.User.Queries;

public record GetUserQuery(string Email): IRequest<GetUserResult>;