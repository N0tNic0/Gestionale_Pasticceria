using FluentValidation;
using Pasticceria.Api.Resources;

namespace Pasticceria.Api.Validators
{
    public class SaveDolceResourceValidator : AbstractValidator<SaveDolceResource>
    {
        public SaveDolceResourceValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(a => a.Quantita)
                .NotNull()
                .GreaterThan(0);

            RuleFor(a => a.Prezzo)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
