using Gerenciador.Processos.Data.Context;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task CommitAsync() => await _context.SaveChangesAsync();

        public Task RollbackAsync() => Task.CompletedTask;

    }
}
