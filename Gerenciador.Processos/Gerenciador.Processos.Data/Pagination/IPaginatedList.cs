using System.Collections.Generic;

namespace Gerenciador.Processos.Data.Pagination
{
    public interface IPaginatedList<T>
    {
        int CurrentPage { get; }

        IReadOnlyList<T> Items { get; }
        
        int ItemsOnPage { get; }
        
        bool HasNextPage { get; }
        
        bool HasPreviousPage { get; }
        
        int PageSize { get; }
        
        int TotalItems { get; }
        
        int TotalPages { get; }
    }
}