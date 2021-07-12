namespace Gerenciador.Processos.Contracts.v1.Requests
{
    public record CreateCustomerRequest
    {
        public string Name { get; init; }
        
        public string Cnpj { get; init; }

        public string State { get; init; }
    }
}
