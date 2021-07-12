using Gerenciador.Processos.Data.Context;
using Gerenciador.Processos.Data.Models;
using Gerenciador.Processos.Data.Pagination;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CustomerModel> CreateAsync(CustomerModel entity, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(CustomerModel entity, CancellationToken cancellationToken)
        {
            await Task.Run(() => _context.Customers.Remove(entity), cancellationToken);
        }

        public async Task<CustomerModel> GetAsync(long id, CancellationToken cancellationToken)
        {
            return await _context.Customers.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<PaginatedList<CustomerModel>> GetAllAsync(PageableFilter filter, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .OrderBy(x => x.Id)
                .ToPaginatedListAsync(filter, cancellationToken);
        }

        public async Task<CustomerModel> UpdateAsync(CustomerModel entity, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                _context.Customers.Update(entity);
                return entity;
            }, cancellationToken);
        }
    }
}
