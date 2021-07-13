using Gerenciador.Processos.Data.Models;
using Gerenciador.Processos.Data.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.Repositories
{
    public interface IProcessRepository
    {
        Task<ProcessModel> CreateAsync(ProcessModel entity, CancellationToken cancellationToken);

        Task DeleteAsync(ProcessModel entity, CancellationToken cancellationToken);
        
        Task<PaginatedList<ProcessModel>> GetAllAsync(PageableFilter filter, CancellationToken cancellationToken);
        
        Task<ProcessModel> GetAsync(long id, CancellationToken cancellationToken);
        
        Task<ProcessModel> UpdateAsync(ProcessModel entity, CancellationToken cancellationToken);
    }
}