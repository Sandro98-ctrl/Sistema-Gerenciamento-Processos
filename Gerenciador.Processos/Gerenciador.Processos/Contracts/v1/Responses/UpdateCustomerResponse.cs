namespace Gerenciador.Processos.Contracts.v1.Responses
{
    public record UpdateCustomerResponse
    {
        public string Name { get; init; }

        public string Cnpj { get; init; }

        public string State { get; init; }
    }
}
