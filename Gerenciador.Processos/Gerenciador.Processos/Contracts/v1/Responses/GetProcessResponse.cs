namespace Gerenciador.Processos.Contracts.v1.Responses
{
    public record GetProcessResponse
    {
        public long Id { get; init; }

        public long CustomerId { get; init; }

        public string Number { get; init; }

        public string State { get; init; }

        public decimal Amount { get; init; }

        public bool Active { get; init; }

        public string CreatedAt { get; init; }
    }
}
