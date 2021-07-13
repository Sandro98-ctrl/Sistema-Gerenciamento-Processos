using Gerenciador.Processos.Contracts.v1.Queries;
using Gerenciador.Processos.Contracts.v1.Requests;
using Gerenciador.Processos.Contracts.v1.Responses;
using Gerenciador.Processos.Custom.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Services
{
    public interface ICustomerService
    {
        Task<DataResult<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken);

        Task<Result> DeleteCustomerAsync(long id, CancellationToken cancellationToken);

        Task<Result> GetCustomerAsync(long id, CancellationToken cancellationToken);

        Task<Result> GetCustomersAsync(PageableQuery query, CancellationToken cancellationToken);

        Task<Result> UpdateCustomerNameAsync(long id, UpdateCustomerNameRequest request, CancellationToken cancellationToken);
    }
}
