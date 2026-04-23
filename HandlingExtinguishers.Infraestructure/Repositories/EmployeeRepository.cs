using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
