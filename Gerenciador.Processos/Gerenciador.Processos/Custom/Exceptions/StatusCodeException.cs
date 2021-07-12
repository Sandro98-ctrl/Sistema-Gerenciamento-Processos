using System;
using System.Net;

namespace Gerenciador.Processos.Custom.Exceptions
{
    public class StatusCodeException : Exception
    {
        public StatusCodeException(HttpStatusCode statusCode, string message) 
            : base(message)
        {
            StatusCode = (int)statusCode;
        }

        public int StatusCode { get; }
    }
}
