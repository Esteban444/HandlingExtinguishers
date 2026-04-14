using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
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
