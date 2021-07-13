using Gerenciador.Processos.Data.Context;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _context;

        public UnitOfWork(IDataContext context)
        {
            _context = context;
        }

        public async Task CommitAsync() => await _context.SaveChangesAsync();

        public Task RollbackAsync() => Task.CompletedTask;

    }
}
