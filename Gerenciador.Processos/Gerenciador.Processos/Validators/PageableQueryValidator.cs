using FluentValidation;
using Gerenciador.Processos.Contracts.v1.Queries;

namespace Gerenciador.Processos.Validators
{
    public class PageableQueryValidator : AbstractValidator<PageableQuery>
    {
        public PageableQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
