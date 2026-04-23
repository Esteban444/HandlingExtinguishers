namespace HandlingExtinguishers.Models.Pagination;

public class PagedResponse<T>( T data, int pageNumber, int pageSize ) : OperationResult
{
    public int PageNumber { get; set; } = pageNumber;

    public int PageSize { get; set; } = pageSize;

    public int TotalPages { get; set; }

    public int TotalRecords { get; set; }

    public T Resource { get; set; } = data;
}
