namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Products;
using Microsoft.EntityFrameworkCore;
#endregion

public class ProductService( IProductRepository repository, IMapper mapper ) : IProductService
{
    private readonly IProductRepository repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<ProductRequest>> SearchProduct( FilterProduct filter )
    {
        var result = await repository.GetAll().ToListAsync();

        var response = mapper.Map<IEnumerable<ProductRequest>>( result );

        return response;
    }

    public async Task<ProductRequest> SearchProductById( Guid productId )
    {
        var result = await repository.FindBy( product => product.ProductId == productId).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<ProductRequest>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ProductNotFound );
        }
    }

    public async Task<ProductResponse> CreateProduct( ProductRequest request )
    {
        var result = mapper.Map<Product>( request );

        await repository.Add( result );

        var response = mapper.Map<ProductResponse>( result );

        return response;
    }

    public async Task<ProductResponse> UpdateProduct( Guid productId, ProductRequest request )
    {
        var result = await repository.FindBy( product => product.ProductId == productId ).FirstOrDefaultAsync();

        if ( result is not null ) 
        {
            result.TypeExtinguisherId = request.TypeExtinguisherId;
            result.WeightExtinguisherId = request.WeightExtinguisherId;
            result.TypeProduct = request.ProductType;

            await repository.Update( result );

            var response = mapper.Map<ProductResponse>( result ) ;

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ProductNotFound );
        }
    }

    public async Task<ProductResponse> DeleteProduct( Guid productId )
    {
        var result = await repository.FindBy( product => product.ProductId == productId).FirstOrDefaultAsync();

        if ( result is not null ) 
        {
            try
            {
                await repository.Delete( result );

                var response = mapper.Map<ProductResponse>( result );

                return response;
            }
            catch ( Exception )
            {

                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedProduct );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ProductNotFound );
        }
    }
}
