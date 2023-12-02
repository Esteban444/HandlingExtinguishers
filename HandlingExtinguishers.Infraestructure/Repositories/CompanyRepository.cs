using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingFireExtinguishers.Infraestructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, IRepositoryCompany
    {
        public CompanyRepository(HandlingExtinguisherContext contex) : base(contex)
        {

        }
    }
}
