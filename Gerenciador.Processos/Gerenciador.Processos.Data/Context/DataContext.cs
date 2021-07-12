using Gerenciador.Processos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Processos.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<CustomerModel> Customers { get; init; }
    }
}
