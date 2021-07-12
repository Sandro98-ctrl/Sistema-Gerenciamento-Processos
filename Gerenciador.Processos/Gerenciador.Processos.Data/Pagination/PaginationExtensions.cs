using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gerenciador.Processos.Data.Pagination
{
    public static class PaginationExtensions
    {
        public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            return new PaginatedList<T>(source, pageNumber, pageSize);
        }

        public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> source, PageableFilter pageable)
        {
            return new PaginatedList<T>(source, pageable);
        }

        public static Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => new PaginatedList<T>(source, pageNumber, pageSize), cancellationToken);
        }

        public static Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, PageableFilter pageable, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => new PaginatedList<T>(source, pageable), cancellationToken);
        }
    }
}
