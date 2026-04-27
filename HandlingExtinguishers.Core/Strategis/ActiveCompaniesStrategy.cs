namespace HandlingExtinguishers.Core.Strategis;

#region Usings
using HandlingExtinguishers.Contracts.Interfaces.Strategies;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Pagination;
#endregion

public class ActiveCompaniesStrategy : ICompanySearchStrategy
{
    public IQueryable<Company> Apply(IQueryable<Company> query, QueryParameter filter)
    {
        var result = query.Where( company => company.Active );

        if ( filter.OrderBy == "Id" ) filter.OrderBy = "Name";

        return result;
    }
}
