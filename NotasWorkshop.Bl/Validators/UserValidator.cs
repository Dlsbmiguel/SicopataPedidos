using FluentValidation;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Bl.Validators.Generic;

namespace SicopataPedidos.Bl.Validators
{
    public class UserValidator : BaseValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("Name field should be only 20 characters long");
            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(8)
                .WithMessage("Password field should be at least 8 characters long");
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50)
                .WithMessage("Email address should be only 50 characters long");
        }
    }
}
