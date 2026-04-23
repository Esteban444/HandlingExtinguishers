namespace HandlingExtinguishers.Contracts.Interfaces.Services;

using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Prices;

public interface IPriceService 
{
    Task<IEnumerable<PriceResponse>> SearchPrices( FilterPrices filter );

    Task<PriceResponse> SearchPriceById( Guid priceId );

    Task<PriceResponse> CreatePrice(PriceRequest price );

    Task<PriceResponse> UpdatePrice( Guid priceId, PriceRequest price );

    Task<PriceResponse> DeletePrice( Guid priceId );
}
