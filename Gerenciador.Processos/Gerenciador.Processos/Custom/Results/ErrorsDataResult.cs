using System.Collections.Generic;

namespace Gerenciador.Processos.Custom.Results
{
    public class ErrorsDataResult : Result
    {
        public ErrorsDataResult(IEnumerable<object> errors) : base(false)
        {
            Errors = errors;
        }

        public IEnumerable<object> Errors { get; }
    }
}
