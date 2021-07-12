using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerenciador.Processos.Data.Pagination
{
    public class PaginatedList<T> : IPaginatedList<T>
    {
        public PaginatedList(IQueryable<T> queryable, PageableFilter pageable)
            : this(queryable, pageable.PageNumber, pageable.PageSize) { }

        public PaginatedList(IQueryable<T> queryable, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalItems = queryable.Count();
            TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);
            Items = GetElements(queryable);
            ItemsOnPage = Items.Count;
        }

        public int CurrentPage { get; }

        public int PageSize { get; }

        public int TotalItems { get; }

        public int ItemsOnPage { get; }

        public int TotalPages { get; }

        public IReadOnlyList<T> Items { get; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        private IReadOnlyList<T> GetElements(IQueryable<T> queryable)
        {
            return queryable
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }
}
