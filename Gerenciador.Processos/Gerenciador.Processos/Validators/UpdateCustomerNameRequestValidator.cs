using FluentValidation;
using Gerenciador.Processos.Contracts.v1.Requests;

namespace Gerenciador.Processos.Validators
{
    public class UpdateCustomerNameRequestValidator : AbstractValidator<UpdateCustomerNameRequest>
    {
        public UpdateCustomerNameRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
