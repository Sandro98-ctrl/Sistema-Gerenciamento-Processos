using Gerenciador.Processos.Data.Models;
using Gerenciador.Processos.Data.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerModel> CreateAsync(CustomerModel entity, CancellationToken cancellationToken);

        Task DeleteAsync(CustomerModel entity, CancellationToken cancellationToken);
        
        Task<PaginatedList<CustomerModel>> GetAllAsync(PageableFilter filter, CancellationToken cancellationToken);

        Task<CustomerModel> GetAsync(long id, CancellationToken cancellationToken);

        Task<CustomerModel> UpdateAsync(CustomerModel entity, CancellationToken cancellationToken);
    }
}
