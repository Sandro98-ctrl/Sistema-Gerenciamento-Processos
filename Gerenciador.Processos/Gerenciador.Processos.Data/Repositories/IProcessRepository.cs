using Gerenciador.Processos.Data.Models;
using Gerenciador.Processos.Data.Pagination;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.Repositories
{
    public interface IProcessRepository
    {
        Task<long> CountAsync(Expression<Func<ProcessModel, bool>> predicate, CancellationToken cancellationToken);
        
        Task<ProcessModel> CreateAsync(ProcessModel entity, CancellationToken cancellationToken);

        Task DeleteAsync(ProcessModel entity, CancellationToken cancellationToken);
        
        Task<List<ProcessModel>> GetActivesAsync(CancellationToken cancellationToken);
        
        Task<PaginatedList<ProcessModel>> GetAllAsync(PageableFilter filter, CancellationToken cancellationToken);
        
        Task<ProcessModel> GetAsync(long id, CancellationToken cancellationToken);
        
        Task<List<ProcessModel>> GetByAsync(long customerId, string state, CancellationToken cancellationToken);
        
        Task<ProcessModel> UpdateAsync(ProcessModel entity, CancellationToken cancellationToken);
        
        Task<List<ProcessModel>> GetByAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
        
        Task<List<ProcessModel>> GetSameStateByCustomerIdAsync(long customerId, CancellationToken cancellationToken);
        
        Task<List<ProcessModel>> GetContainingInitialsAsync(string initials, CancellationToken cancellationToken);
    }
}