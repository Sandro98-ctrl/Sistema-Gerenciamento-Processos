namespace Gerenciador.Processos.Custom.Results
{
    public class DataResult<T> : Result
    {
        public DataResult(T data) : base(true)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
