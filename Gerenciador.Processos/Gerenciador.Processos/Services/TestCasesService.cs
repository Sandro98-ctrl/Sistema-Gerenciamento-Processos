using Gerenciador.Processos.Custom.Results;
using Gerenciador.Processos.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Services
{
    public class TestCasesService : BaseService, ITestCasesService
    {
        private readonly IProcessRepository _processRepository;

        public TestCasesService(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

        public async Task<Result> ExecuteTest1Async(CancellationToken cancellationToken)
        {
            var processes = await _processRepository.GetActivesAsync(cancellationToken);

            var data = new { totalAmount = processes.Sum(x => x.Amount).ToString("C0") };

            return SuccessDataResult(data);
        }

        public async Task<Result> ExecuteTest2Async(CancellationToken cancellationToken)
        {
            var processes = await _processRepository.GetByAsync(1, "Rio de Janeiro", cancellationToken);

            var data = new { averageAmount = processes.Average(x => x.Amount).ToString("C0") };

            return SuccessDataResult(data);
        }

        public async Task<Result> ExecuteTest3Async(CancellationToken cancellationToken)
        {
            var numberOfProcesses = await _processRepository.CountAsync(x => x.Amount > 100_000, cancellationToken);

            var data = new { numberOfProcesses };

            return SuccessDataResult(data);
        }

        public async Task<Result> ExecuteTest4Async(CancellationToken cancellationToken)
        {
            var startDate = new DateTime(2007, 9, 1);
            var endDate = new DateTime(2007, 9, 30, 23, 59, 59);

            var processes = await _processRepository.GetByAsync(startDate, endDate, cancellationToken);

            var data = new { processes = processes.Select(x => x.Number) };

            return SuccessDataResult(data);
        }

        public async Task<Result> ExecuteTest5Async(ICustomerRepository customerRepository, CancellationToken cancellationToken)
        {
            var customers = await customerRepository.GetAllAsync(cancellationToken);

            var processDict = new Dictionary<string, IEnumerable<string>>();

            foreach (var c in customers)
            {
                var processes = await _processRepository.GetSameStateByCustomerIdAsync(c.Id, cancellationToken);
                processDict.Add(c.Name, processes.Select(x => x.Number));
            }

            var data = processDict.Select(kvp => new
            {
                Client = kvp.Key,
                Processes = kvp.Value
            });

            return SuccessDataResult(data);
        }

        public async Task<Result> ExecuteTest6Async(CancellationToken cancellationToken)
        {
            var processes = await _processRepository.GetContainingInitialsAsync("TRAB", cancellationToken);

            var data = new
            {
                processes = processes.Select(x => x.Number)
            };

            return SuccessDataResult(data);
        }
    }
}
