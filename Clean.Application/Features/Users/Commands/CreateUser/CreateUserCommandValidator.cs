using FluentValidation;

namespace Clean.Application.Features.Users.Commands.CreateUser;
public class UpdateUserValidator : AbstractValidator<CreateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress().WithMessage("Invalid email address")
            .NotEmpty().WithMessage("Email cannot be empty");

        RuleFor(u => u.FirstName)
            .MaximumLength(100).WithMessage("first name cannot be more than 100 character")
            .NotEmpty().WithMessage("First name cannot be empty");

        RuleFor(u => u.LastName)
            .MaximumLength(100).WithMessage("last name cannot be more than 100 character")
            .NotEmpty().WithMessage("Last name cannot be empty");

        RuleFor(u => u.UserName)
            .MaximumLength(100).WithMessage("Username cannot be more than 100 character")
            .NotEmpty().WithMessage("Username cannot be empty");

        RuleFor(command => command.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters");
    }
}
