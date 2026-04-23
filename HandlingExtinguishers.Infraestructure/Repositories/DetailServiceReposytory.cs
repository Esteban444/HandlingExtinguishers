using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class DetailServiceReposytory : BaseRepository<DetailService>, IDetailServiceRepository
    {
        public DetailServiceReposytory(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
