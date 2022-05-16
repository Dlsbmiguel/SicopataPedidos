using FluentValidation;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Bl.Validators.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Bl.Validators
{
    public class LogInValidator: BaseValidator<LogInDto>
    {
        public LogInValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Must enter an existing email");
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password field is required");
        }
    }
}
