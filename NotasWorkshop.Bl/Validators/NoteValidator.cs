using FluentValidation;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Bl.Validators.Generic;

namespace SicopataPedidos.Bl.Validators
{
    public class NoteValidator : BaseValidator<NoteDto>
    {
        public NoteValidator()
        {
            RuleFor(x => x.Title)
                .Length(11)
                .WithMessage("El campo titulo debe contener 11 dígitos");
        }
    }
}
