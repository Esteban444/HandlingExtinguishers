using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class DetailExtinguisherClientRepository : BaseRepository<DetailExtinguisherClient>, IDetailExtinguisherClientRepository
    {
        public DetailExtinguisherClientRepository(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
