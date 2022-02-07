using FluentValidation;
using Pasticceria.Api.Resources;

namespace Pasticceria.Api.Validators
{
    public class SaveIngredienteResourceValidator : AbstractValidator<SaveIngredienteResource>
    {
        public SaveIngredienteResourceValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
