using HandlingExtinguisher.Dto;

namespace HandlingExtinguishers.Models.Pagination
{
    public class PagedResponse<T> : OperationResult
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public T Resource { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Resource = data;
        }

    }
}
