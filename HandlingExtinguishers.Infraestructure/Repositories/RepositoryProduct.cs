using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryProduct : BaseRepository<Product>, IRepositoryProduct
    {
        public RepositoryProduct(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
