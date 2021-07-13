using FluentValidation;
using Gerenciador.Processos.Contracts.v1.Requests;

namespace Gerenciador.Processos.Validators
{
    public class CreateProcessRequestValidator : AbstractValidator<CreateProcessRequest>
    {
        public CreateProcessRequestValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0);

            RuleFor(x => x.Number)
                .NotEmpty();

            RuleFor(x => x.State)
                .NotEmpty();

            RuleFor(x => x.Amount)
                .GreaterThan(0);
        }
    }
}
