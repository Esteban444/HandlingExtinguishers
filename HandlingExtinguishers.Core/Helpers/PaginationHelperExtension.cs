using HandlingExtinguishers.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace HandlingFireExtinguisher.Core.Helpers
{
    public static class PaginationHelper
    {
        public static PagedResponse<IEnumerable<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationParameter validFilter, int totalRecords)
        {
            var respose = new PagedResponse<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            respose.IsSuccess = true;
            return respose;
        }

        public static async Task<PagedResponse<IEnumerable<TModel>>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            PaginationParameter filter)
            where TModel : class
        {
            var totalItemsCountTask = query.AsNoTracking().Count();

            var startRow = (filter.PageNumber - 1) * filter.PageSize;
            var data = await query
                       .AsNoTracking()
                       .Skip(startRow)
                       .Take(filter.PageSize)
                       .ToListAsync();

            return CreatePagedReponse(data, filter, totalItemsCountTask);
        }
    }

}
