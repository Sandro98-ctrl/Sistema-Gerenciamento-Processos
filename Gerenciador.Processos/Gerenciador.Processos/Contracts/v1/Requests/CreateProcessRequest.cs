namespace Gerenciador.Processos.Contracts.v1.Requests
{
    public record CreateProcessRequest
    {
        public long CustomerId { get; init; }

        public string Number { get; init; }

        public string State { get; init; }

        public decimal Amount { get; init; }
    }
}
