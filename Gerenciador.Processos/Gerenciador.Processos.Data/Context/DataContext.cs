using Gerenciador.Processos.Data.Extensions;
using Gerenciador.Processos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Processos.Data.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.CreateAndPopulate();
        }

        public DbSet<CustomerModel> Customers { get; init; }

        public DbSet<ProcessModel> Processes { get; init; }
    }
}
