namespace HandlingExtinguishers.Models.Pagination
{
    public class PaginationParameter
    {
        /// <summary>
        /// Gets or sets the page number of the pagination filter.
        /// </summary>
        /// <value>The page number's pagination filter.</value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size of the pagination filter.
        /// </summary>
        /// <value>The page size's pagination filter.</value>
        public int PageSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the PaginationParameter class with default values.
        /// </summary>
        /// <remarks>The default values are PageNumber set to 1 and PageSize set to 10. These defaults
        /// ensure that pagination starts from the first page and returns a standard page size unless specified
        /// otherwise.</remarks>
        public PaginationParameter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        /// <summary>   
        /// Initializes a new instance of the PaginationParameter class with specified values.
        /// </summary>
        /// <param name="pageNumber">The page number for the pagination filter.</param>
        /// <param name="pageSize">The page size for the pagination filter.</param>
        public PaginationParameter( int pageNumber, int pageSize )
        {
            this.PageNumber = pageNumber <= 1 ? 1 : pageNumber;
            this.PageSize = pageSize <= 1 ? 10 : pageSize > 100 ? 100 : pageSize;
        }
    }
}
