namespace Gerenciador.Processos.Contracts.v1.Requests
{
    public record UpdateCustomerNameRequest
    {
        public string Name { get; init; }
    }
}
