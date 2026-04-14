using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryProduct : BaseRepository<Product>, IRepositoryProduct
    {
        public RepositoryProduct(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
