namespace HandlingExtinguishers.Contracts.Interfaces.Services;

using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Products;

public interface IProductService
{
    Task<IEnumerable<ProductRequest>> SearchProduct( FilterProduct filter );

    Task<ProductRequest> SearchProductById( Guid productId  );

    Task<ProductResponse> CreateProduct( ProductRequest request );

    Task<ProductResponse> UpdateProduct( Guid productId, ProductRequest request );

    Task<ProductResponse> DeleteProduct( Guid productId );
}
