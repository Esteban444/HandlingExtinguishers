namespace HandlingExtinguishers.Core.Strategis;

#region Usings
using HandlingExtinguishers.Contracts.Interfaces.Strategies;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Pagination;
#endregion

public class FilteredCompaniesStrategy : ICompanySearchStrategy
{
    public IQueryable<Company> Apply( IQueryable<Company> query, QueryParameter filter )
    {
        var result = query.Where( company => company.Active );

        if ( filter.OrderBy == "Id" ) filter.OrderBy = "Name";

        if ( !string.IsNullOrEmpty( filter.Search ) )
            result = result.Where( company => company.Name!.ToLower().Contains( filter.Search.ToLower() ) );

        return result;
    }
}
