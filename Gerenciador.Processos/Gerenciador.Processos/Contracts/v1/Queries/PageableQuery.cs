using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Processos.Contracts.v1.Queries
{
    public record PageableQuery
    {
        [FromQuery(Name = "pageNumber")]
        public int PageNumber { get; init; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; init; } = 50;
    }
}
