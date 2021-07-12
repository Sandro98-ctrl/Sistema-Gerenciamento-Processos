using Gerenciador.Processos.Custom.Results;

namespace Gerenciador.Processos.Services
{
    public abstract class BaseService
    {
        public Result SuccessResult()
        {
            return new Result(true);
        }

        public DataResult<T> SuccessDataResult<T>(T data)
        {
            return new DataResult<T>(data);
        }
    }
}
