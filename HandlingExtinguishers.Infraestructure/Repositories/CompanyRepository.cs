namespace HandlingExtinguishers.Infraestructure.Repositories;

using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(HandlingExtinguisherContext contex) : base(contex)
    {

    }
}
