using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace HandlingExtinguishers.Infraestructure.Repositories
{
    public class RepositoryCompany : BaseRepository<Companies>, IRepositoryCompany
    {
        public RepositoryCompany(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
