using Gerenciador.Processos.Custom.Results;
using Gerenciador.Processos.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Services
{
    public interface ITestCasesService
    {
        Task<Result> ExecuteTest1Async(CancellationToken cancellationToken);
        
        Task<Result> ExecuteTest2Async(CancellationToken cancellationToken);
        
        Task<Result> ExecuteTest3Async(CancellationToken cancellationToken);
        
        Task<Result> ExecuteTest4Async(CancellationToken cancellationToken);
        
        Task<Result> ExecuteTest5Async(ICustomerRepository customerRepository, CancellationToken cancellationToken);
        
        Task<Result> ExecuteTest6Async(CancellationToken cancellationToken);
    }
}