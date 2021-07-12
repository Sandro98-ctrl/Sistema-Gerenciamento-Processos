using Gerenciador.Processos.Installers;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InstallerExtensions
    {
        public static IServiceCollection AddInstallers<T>(this IServiceCollection services, IConfiguration configuration) where T : class
        {
            var installers = typeof(T).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>();

            foreach (var installer in installers)
            {
                installer.InstallServices(services, configuration);
            }

            return services;
        }
    }
}
