using Gerenciador.Processos.Contracts.v1.Queries;
using Gerenciador.Processos.Contracts.v1.Requests;
using Gerenciador.Processos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Controllers.v1
{
    [ApiController]
    [Route("api/v1/processes")]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProcess(CreateProcessRequest request, CancellationToken cancellationToken)
        {
            var response = await _processService.CreateProcessAsync(request, cancellationToken);

            var baseUri = Url.ActionLink();
            var locationUrl = baseUri + "/" + response.Data.Id;

            return Created(locationUrl, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProcesses([FromQuery] PageableQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _processService.GetProcessesAsync(query, cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcess(long id, CancellationToken cancellationToken)
        {
            return Ok(await _processService.GetProcessAsync(id, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcess(long id, CancellationToken cancellationToken)
        {
            return Ok(await _processService.DeleteProcessAsync(id, cancellationToken));
        }
    }
}
