using Gerenciador.Processos.Custom.Exceptions;
using Gerenciador.Processos.Custom.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gerenciador.Processos.Filters
{
    public class ResultErrorExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled && context.Exception is StatusCodeException exception)
            {
                var result = new ErrorsDataResult(new[] { new { exception.Message } });

                context.Result = new ObjectResult(result) { StatusCode = exception.StatusCode };
                context.ExceptionHandled = true;
            }
        }
    }
}
