using FluentValidation;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Bl.Validators.Generic;

namespace SicopataPedidos.Bl.Validators
{
    public class CategoriesValidator : BaseValidator<CategoriesDto>
    {
        public CategoriesValidator()
        {

            RuleFor(x => x.CategoryName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("CategoryName field is required and shouldn't be more than 20 characters long.");
        }
    }
}
