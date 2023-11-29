using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositorioEmpleado : BaseRepository<Employee>, IRepositoryEmployee
    {
        public RepositorioEmpleado(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
