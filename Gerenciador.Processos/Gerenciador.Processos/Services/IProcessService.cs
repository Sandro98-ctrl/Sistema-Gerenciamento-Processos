using Gerenciador.Processos.Contracts.v1.Queries;
using Gerenciador.Processos.Contracts.v1.Requests;
using Gerenciador.Processos.Contracts.v1.Responses;
using Gerenciador.Processos.Custom.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Services
{
    public interface IProcessService
    {
        Task<DataResult<CreateProcessResponse>> CreateProcessAsync(CreateProcessRequest request, CancellationToken cancellationToken);
        
        Task<Result> GetProcessAsync(long id, CancellationToken cancellationToken);
        
        Task<Result> GetProcessesAsync(PageableQuery query, CancellationToken cancellationToken);
    }
}