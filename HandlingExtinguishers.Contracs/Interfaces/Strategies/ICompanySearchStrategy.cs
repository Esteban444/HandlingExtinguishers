namespace HandlingExtinguishers.Contracts.Interfaces.Strategies;

using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Pagination;

public interface ICompanySearchStrategy
{
    IQueryable<Company> Apply( IQueryable<Company> query, QueryParameter filter );
}
