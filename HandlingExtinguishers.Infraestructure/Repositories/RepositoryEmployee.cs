using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructure.Repositories
{
    public class RepositoryEmployee : BaseRepository<Employee>, IRepositoryEmployee
    {
        public RepositoryEmployee(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
