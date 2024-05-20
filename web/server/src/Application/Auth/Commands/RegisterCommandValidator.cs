using FluentValidation;

namespace Application.Auth.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            .Length(6, 8).WithMessage("Password must be between 6 and 8 characters")
            .Must(ContainNumber).WithMessage("Password must contain at least one number")
            .Must(ContainSpecialChar).WithMessage("Password must contain at least one special character");
    }

    private bool ContainNumber(string arg)
    {
        return arg.Any(char.IsDigit);
    }

    private bool ContainSpecialChar(string arg)
    {
        return arg.Any(ch => !char.IsLetterOrDigit(ch));
    }
}