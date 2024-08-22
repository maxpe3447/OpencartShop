using Domain.Models;
using Api.Helpers;

namespace Domain.Extensions;

public static class PaginationExtensions
{
    public static PaginationList<T> AsPagination<T>(this IQueryable<T> dbQuery, 
        PaginationQuery paginationQuery)
    {
        return new PaginationList<T>
        {
            TotalCount = dbQuery.Count(),
            List = dbQuery
                .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
                .Take(paginationQuery.PerPage)
        };
    }
}
