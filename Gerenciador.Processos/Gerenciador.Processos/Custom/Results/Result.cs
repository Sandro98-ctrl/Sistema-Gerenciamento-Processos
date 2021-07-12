namespace Gerenciador.Processos.Custom.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}
