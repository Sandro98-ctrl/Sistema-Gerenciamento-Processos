using System.Net;

namespace Gerenciador.Processos.Custom.Exceptions
{
    public class BadRequestException : StatusCodeException
    {
        public BadRequestException(string message)
            : base(HttpStatusCode.BadRequest, message) { }
    }
}
