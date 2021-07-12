using Gerenciador.Processos.Custom.Results;
using Gerenciador.Processos.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace Gerenciador.Processos.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers(configure =>
                {
                    configure.Filters.Add<ResultErrorExceptionFilter>();
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = CustomInvalidModelStateResponse;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerenciador.Processos", Version = "v1" });
            });
        }

        private IActionResult CustomInvalidModelStateResponse(ActionContext context)
        {
            var errors = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(kvp => new
                {
                    FieldName = kvp.Key,
                    Messages = kvp.Value.Errors.Select(x => x.ErrorMessage)
                });

            return new BadRequestObjectResult(new ErrorsDataResult(errors));
        }
    }
}
