using FluentValidation;
using Pasticceria.Api.Resources;

namespace Pasticceria.Api.Validators
{
    public class SaveIngredientiOfDolceResourceValidator : AbstractValidator<SaveIngredientiOfDolciResource>
    {
        public SaveIngredientiOfDolceResourceValidator()
        {
            RuleFor(a => a.Quantita)
                .NotNull();

            RuleFor(a => a.UnitaDiMisura)
                .NotNull();
        }
    }
}
