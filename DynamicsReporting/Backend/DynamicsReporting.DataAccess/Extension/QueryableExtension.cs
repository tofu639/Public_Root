using Dapper;
using DynamicsReporting.Models.Base;
using Microsoft.EntityFrameworkCore;
 
using System.Data;
using System.Text.RegularExpressions;

 
internal static class QueryableExtension
{
    public static PaginatedResult<T> GetPagination<T>(this IEnumerable<T> collection, int currentPage, int pageSize) where T : class
    {
        int totalCount = collection.Count();
        int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        var paginatedQuery = collection.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        return new PaginatedResult<T>
        {
            Data = paginatedQuery,
            Pagination =
                {
                    TotalRecords = totalCount,
                    PageSize = pageSize,
                    TotalPages = totalPages,
                    CurrentPage = currentPage
                }
        };
    }

    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int currentPage, int pageSize)
    {
        return query.Skip((currentPage - 1) * pageSize).Take(pageSize);
    }

    public static async Task<PaginatedResult<T>> GetPaginatedResult<T>(this IQueryable<T> query, int currentPage, int pageSize)
    {
        int totalCount = await query.CountAsync();
        int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        var paginatedQuery = query.ApplyPagination(currentPage, pageSize);

        return new PaginatedResult<T>
        {
            Data = await paginatedQuery.ToListAsync(),
            Pagination = new Pagination()
            {
                TotalRecords = totalCount,
                PageSize = pageSize,
                TotalPages = totalPages,
                CurrentPage = currentPage
            }
        };
    }
}
