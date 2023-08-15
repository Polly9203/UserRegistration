using FluentValidation;
using UserRegistration.BLL.Models.Registration;

namespace UserRegistration.BLL.Validators
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidator()
        {
            RuleFor(user => user.Login).NotEmpty().WithMessage("Login cannot be empty");
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit");
            RuleFor(user => user.PasswordConfirmation).Equal(user => user.Password).WithMessage("Passwords do not match");
        }
    }
}
