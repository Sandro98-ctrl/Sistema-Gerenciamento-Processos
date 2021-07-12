using Gerenciador.Processos.Contracts.v1.Queries;
using Gerenciador.Processos.Contracts.v1.Requests;
using Gerenciador.Processos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Controllers.v1
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = await _customerService.CreateCustomerAsync(request, cancellationToken);

            var baseUri = Url.ActionLink();
            var locationUrl = baseUri + "/" + response.Data.Id;

            return Created(locationUrl, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] PageableQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _customerService.GetCustomersAsync(query, cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(long id, CancellationToken cancellationToken)
        {
            return Ok(await _customerService.GetCustomerAsync(id, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id, CancellationToken cancellationToken)
        {
            return Ok(await _customerService.DeleteCustomerAsync(id, cancellationToken));
        }
    }
}
