using Gerenciador.Processos.Data.Context;
using Gerenciador.Processos.Data.Models;
using Gerenciador.Processos.Data.Pagination;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly IDataContext _context;

        public ProcessRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<ProcessModel> CreateAsync(ProcessModel entity, CancellationToken cancellationToken)
        {
            await _context.Processes.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(ProcessModel entity, CancellationToken cancellationToken)
        {
            await Task.Run(() => _context.Processes.Remove(entity), cancellationToken);
        }

        public async Task<ProcessModel> GetAsync(long id, CancellationToken cancellationToken)
        {
            return await _context.Processes.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<PaginatedList<ProcessModel>> GetAllAsync(PageableFilter filter, CancellationToken cancellationToken)
        {
            return await _context.Processes
                .OrderBy(x => x.Id)
                .ToPaginatedListAsync(filter, cancellationToken);
        }

        public async Task<ProcessModel> UpdateAsync(ProcessModel entity, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                _context.Processes.Update(entity);
                return entity;
            }, cancellationToken);
        }
    }
}
