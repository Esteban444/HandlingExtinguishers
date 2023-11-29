using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace HandlingFireExtinguishers.Infraestructure.Repositories
{
    public class CompanyRepository : BaseRepository<Companies>, IRepositoryCompany
    {
        public CompanyRepository(HandlingExtinguisherContext contex) : base(contex)
        {

        }
    }
}
