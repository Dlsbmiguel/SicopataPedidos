using FluentValidation;
using SicopataPedidos.Bl.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Bl.Validators.Generic
{
    public class ProductsValidator: BaseValidator<ProductsDto>
    {
        public ProductsValidator()
        {
            RuleFor(x => x.ProductPrice)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Product price can't be 0");
            RuleFor(x => x.ProductName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("Product name should be only 20 characters long");
            RuleFor(x => x.ProductDescription)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Product description should be only 50 characters long");
            RuleFor(x => x.InStock)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product stock shouldn't be empty");

        }
    }
}
