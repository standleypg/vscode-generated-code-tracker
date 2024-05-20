using FluentValidation;

namespace Application.User.Queries;

public class GetUserQueryValidator: AbstractValidator<GetUserQuery>
{
    public GetUserQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
    }
}