using Gerenciador.Processos.Data.Repositories;
using Gerenciador.Processos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestCasesController : ControllerBase
    {
        private readonly ITestCasesService _testCasesService;

        public TestCasesController(ITestCasesService testCasesService)
        {
            _testCasesService = testCasesService;
        }

        [HttpPost("teste-1")]
        public async Task<IActionResult> ExecuteTest1(CancellationToken cancellationToken)
        {
            return Ok(await _testCasesService.ExecuteTest1Async(cancellationToken));
        }

        [HttpPost("teste-2")]
        public async Task<IActionResult> ExecuteTest2(CancellationToken cancellationToken)
        {
            return Ok(await _testCasesService.ExecuteTest2Async(cancellationToken));
        }

        [HttpPost("teste-3")]
        public async Task<IActionResult> ExecuteTest3(CancellationToken cancellationToken)
        {
            return Ok(await _testCasesService.ExecuteTest3Async(cancellationToken));
        }

        [HttpPost("teste-4")]
        public async Task<IActionResult> ExecuteTest4(CancellationToken cancellationToken)
        {
            return Ok(await _testCasesService.ExecuteTest4Async(cancellationToken));
        }

        [HttpPost("teste-5")]
        public async Task<IActionResult> ExecuteTest5([FromServices] ICustomerRepository customerRepository, CancellationToken cancellationToken)
        {
            return Ok(await _testCasesService.ExecuteTest5Async(customerRepository, cancellationToken));
        }

        [HttpPost("teste-6")]
        public async Task<IActionResult> ExecuteTest6(CancellationToken cancellationToken)
        {
            return Ok(await _testCasesService.ExecuteTest6Async(cancellationToken));
        }
    }
}
