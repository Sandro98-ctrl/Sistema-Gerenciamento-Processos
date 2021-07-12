using System.Collections.Generic;

namespace Gerenciador.Processos.Contracts.v1.Responses
{
    public record PaginationResponse<T>
    {
        public IEnumerable<T> Items { get; init; }

        public int CurrentPage { get; init; }

        public int PageSize { get; init; }

        public int TotalItems { get; init; }

        public int ItemsOnPage { get; init; }

        public int TotalPages { get; init; }

        public bool HasNextPage { get; init; }

        public bool HasPreviousPage { get; init; }
    }
}
