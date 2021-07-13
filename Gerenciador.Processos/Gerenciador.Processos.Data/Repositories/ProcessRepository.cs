using Gerenciador.Processos.Data.Context;
using Gerenciador.Processos.Data.Models;
using Gerenciador.Processos.Data.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<ProcessModel>> GetActivesAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() => _context.Processes.Where(x => x.Active).ToList(), cancellationToken);
        }

        public async Task<List<ProcessModel>> GetByAsync(long customerId, string state, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _context.Processes
                .Where(x => x.CustomerId == customerId && x.State == state)
                .ToList(),
                cancellationToken);
        }

        public async Task<long> CountAsync(Expression<Func<ProcessModel, bool>> predicate, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _context.Processes.LongCount(predicate), cancellationToken);
        }

        public async Task<List<ProcessModel>> GetByAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _context.Processes
                .Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate)
                .ToList(),
                cancellationToken);
        }

        public async Task<List<ProcessModel>> GetSameStateByCustomerIdAsync(long customerId, CancellationToken cancellationToken)
        {
            return await Task.Run(async () =>
            {
                var customer = await _context.Customers.FindAsync(new object[] { customerId }, cancellationToken);

                return _context.Processes
                   .Where(x => x.CustomerId == customerId && x.State == customer.State)
                   .ToList();
            }, cancellationToken);
        }

        public async Task<List<ProcessModel>> GetContainingInitialsAsync(string initials, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return _context.Processes
                   .Where(x => x.Number.Contains(initials))
                   .ToList();
            }, cancellationToken);
        }
    }
}
