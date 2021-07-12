using Gerenciador.Processos.Data.Context;
using Gerenciador.Processos.Data.Repositories;
using Gerenciador.Processos.Data.UnitOfWork;
using Gerenciador.Processos.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace Gerenciador.Processos.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //DeleteDatabase();

            services.AddDbContext<DataContext>(options =>
            {
                var stringConnection = configuration.GetConnectionString("default");

                options.UseSqlite(stringConnection, 
                    options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        private static void DeleteDatabase()
        {
            const string dbName = "sqlitedbtest";

            if (File.Exists(dbName))
                File.Delete(dbName);
        }
    }
}
