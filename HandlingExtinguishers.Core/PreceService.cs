using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Prices;
using Microsoft.EntityFrameworkCore;

namespace HandlingExtinguishers.Core.Services
{
    public class PreceService( IPriceRepository repositoryPrice, IMapper mapper ) : IPriceService
    {
        private readonly IPriceRepository repositoryPrice = repositoryPrice;
        private readonly IMapper mapper = mapper;

        public async Task<IEnumerable<PriceResponse>> SearchPrices(FilterPrices filtro)
        {
            var result = await repositoryPrice.GetAll().ToListAsync<Price>();

            var response = mapper.Map<IEnumerable<PriceResponse>>( result );

            return response;
        }

        public async Task<PriceResponse> SearchPriceById( Guid priceId )
        {
            var result = await repositoryPrice.FindBy( price => price.PriceId == priceId ).FirstOrDefaultAsync<Price>();

            if ( result != null ) 
            {
                return mapper.Map<PriceResponse>( result );
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.PriceNotFound );
            }
        }

        public async Task<PriceResponse> CreatePrice( PriceRequest request )
        {
            var result = mapper.Map<Price>( request );

            await repositoryPrice.Add( result );

            var response = mapper.Map<PriceResponse>( result );

            return response;
        }


        public async Task<PriceResponse> UpdatePrice( Guid priceId, PriceRequest request )
        {
            var result = await repositoryPrice.FindBy( price => price.PriceId == priceId ).FirstOrDefaultAsync<Price>();

            if ( result is not null)
            {
                result.ProductId = request.ProductId;
                result.Description = request.Description;
                result.Value = request.Value;
                result.Iva = request.Tax;

                await repositoryPrice.Update( result );

                var response = mapper.Map<PriceResponse>( result );

                return response;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.PriceNotFound );
            }
        }

        public async Task<PriceResponse> DeletePrice(Guid priceId)
        {
            var result = await repositoryPrice.FindBy( price => price.PriceId == priceId ).FirstOrDefaultAsync<Price>();

            if ( result is not null )
            {
                try
                {
                    await repositoryPrice.Delete( result );

                    var response = mapper.Map<PriceResponse>( result );

                    return response;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions( HandlingExtinguisherResources.RelatedPrice );
                }
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.PriceNotFound );
            }
        }
    }
}
