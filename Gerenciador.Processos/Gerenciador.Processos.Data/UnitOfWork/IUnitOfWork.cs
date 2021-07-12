using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}