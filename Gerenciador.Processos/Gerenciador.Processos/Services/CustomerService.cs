using Gerenciador.Processos.Contracts.v1.Queries;
using Gerenciador.Processos.Contracts.v1.Requests;
using Gerenciador.Processos.Contracts.v1.Responses;
using Gerenciador.Processos.Custom.Exceptions;
using Gerenciador.Processos.Custom.Results;
using Gerenciador.Processos.Data.Models;
using Gerenciador.Processos.Data.Pagination;
using Gerenciador.Processos.Data.Repositories;
using Gerenciador.Processos.Data.UnitOfWork;
using Mapster;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository; 
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository,
                               IUnitOfWork unitOfWork,
                               ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<DataResult<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Criando cliente: {request.Name} - {request.Cnpj} - {request.State}");

            var customer = request.Adapt<CustomerModel>();

            await _customerRepository.CreateAsync(customer, cancellationToken);
            await _unitOfWork.CommitAsync();

            return SuccessDataResult(customer.Adapt<CreateCustomerResponse>());
        }

        public async Task<Result> GetCustomersAsync(PageableQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Obtendo todos os clientes: {query.PageNumber} - {query.PageSize}");

            var filter = query.Adapt<PageableFilter>();

            var customers = await _customerRepository.GetAllAsync(filter, cancellationToken);

            return SuccessDataResult(customers.Adapt<PaginationResponse<GetCustomerResponse>>());
        }

        public async Task<Result> GetCustomerAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Obtendo cliente: {id}");

            var customer = await _customerRepository.GetAsync(id, cancellationToken);

            if (customer is null)
                throw new BadRequestException($"Cliente com Id: {id} não encontrado");

            return SuccessDataResult(customer.Adapt<GetCustomerResponse>());
        }

        public async Task<Result> UpdateCustomerNameAsync(long id, UpdateCustomerNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Atualizando nome do cliente: {id} - {request.Name}");

            var customer = await _customerRepository.GetAsync(id, cancellationToken);

            if (customer is null)
                throw new BadRequestException($"Cliente com Id: {id} não encontrado");

            customer.Name = request.Name;

            await _customerRepository.UpdateAsync(customer, cancellationToken);
            await _unitOfWork.CommitAsync();

            return SuccessDataResult(customer.Adapt<UpdateCustomerResponse>());
        }

        public async Task<Result> DeleteCustomerAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Checando se o cliente existe: {id}");

            var customer = await _customerRepository.GetAsync(id, cancellationToken);

            if (customer is null)
                throw new BadRequestException($"Cliente com Id: {id} não encontrado");

            _logger.LogInformation($"Deletando cliente: {id}");

            await _customerRepository.DeleteAsync(customer, cancellationToken);
            await _unitOfWork.CommitAsync();

            return SuccessResult();
        }
    }
}
