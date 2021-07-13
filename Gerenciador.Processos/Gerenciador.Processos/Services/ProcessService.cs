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
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Services
{
    public class ProcessService : BaseService, IProcessService
    {
        private readonly IProcessRepository _processRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProcessService> _logger;

        public ProcessService(IProcessRepository processRepository,
                              ICustomerRepository customerRepository,
                              IUnitOfWork unitOfWork,
                              ILogger<ProcessService> logger)
        {
            _processRepository = processRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<DataResult<CreateProcessResponse>> CreateProcessAsync(CreateProcessRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Criando processo: {request.CustomerId} - {request.Number} - {request.State} - {request.Amount}");

            var customer = await _customerRepository.GetAsync(request.CustomerId, cancellationToken);

            if (customer is null)
                throw new BadRequestException($"Cliente com Id: {request.CustomerId} não encontrado");

            var process = request.Adapt<ProcessModel>();
            process.Active = true;
            process.CreatedAt = DateTime.Now;

            await _processRepository.CreateAsync(process, cancellationToken);
            await _unitOfWork.CommitAsync();

            return SuccessDataResult(process.Adapt<CreateProcessResponse>());
        }

        public async Task<Result> GetProcessesAsync(PageableQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Obtendo todos os processos: {query.PageNumber} - {query.PageSize}");

            var filter = query.Adapt<PageableFilter>();

            var processes = await _processRepository.GetAllAsync(filter, cancellationToken);

            return SuccessDataResult(processes.Adapt<PaginationResponse<GetProcessResponse>>());
        }

        public async Task<Result> GetProcessAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Obtendo processo: {id}");

            var customer = await _processRepository.GetAsync(id, cancellationToken);

            if (customer is null)
                throw new BadRequestException($"Cliente com Id: {id} não encontrado");

            return SuccessDataResult(customer.Adapt<GetProcessResponse>());
        }
    }
}
