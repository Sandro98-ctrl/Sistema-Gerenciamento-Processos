using Gerenciador.Processos.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.Context
{
    public interface IDataContext
    {
        DbSet<CustomerModel> Customers { get; }

        DbSet<ProcessModel> Processes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
