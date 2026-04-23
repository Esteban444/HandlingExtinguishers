namespace HandlingExtinguishers.Contracts.Interfaces.Repositories;

#region Usings
using HandlingExtinguishers.Models.Models;
# endregion

public interface IProductRepository : IBaseRepository<Product>
{
    public interface IRepositoryProduct : IBaseRepository<Product>
    {
    }
}
