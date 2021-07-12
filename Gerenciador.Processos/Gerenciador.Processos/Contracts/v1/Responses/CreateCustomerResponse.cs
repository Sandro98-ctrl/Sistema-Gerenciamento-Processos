namespace Gerenciador.Processos.Contracts.v1.Responses
{
    public record CreateCustomerResponse
    {
        public long Id { get; init; }

        public string Name { get; init; }

        public string Cnpj { get; init; }

        public string State { get; init; }
    }
}
