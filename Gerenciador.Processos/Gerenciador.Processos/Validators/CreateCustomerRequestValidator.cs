using FluentValidation;
using Gerenciador.Processos.Contracts.v1.Requests;
using Gerenciador.Processos.Helpers;

namespace Gerenciador.Processos.Validators
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Cnpj)
                .NotEmpty()
                .Must(ValidationHelper.IsCnpj)
                .WithMessage("'Cnpj' inválido");

            RuleFor(x => x.State)
                .NotEmpty();
        }
    }
}
