using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class WeightExtinguisherService : IWeightExtinguisherService
    {
        private readonly IBaseRepository<WeightExtinguisher> repository;
        private readonly IMapper mapper;
        public WeightExtinguisherService( IBaseRepository<WeightExtinguisher> repository, IMapper mapper )
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<WightExtuinguiserDto>> SearchWeightExtinguishers()
        {
            var weightExtinguishers = await repository.GetAll().ToListAsync();

            var weight = mapper.Map<IEnumerable<WightExtuinguiserDto>>( weightExtinguishers );

            return weight;
        }

        public async Task<WightExtuinguiserDto> SearchWeightExtinguisherById( Guid idWeightExtinguisher )
        {
            var weightExtinguisher = await repository.FindBy( weight => weight.WeightExtinguisherId == idWeightExtinguisher ).FirstOrDefaultAsync();

            if ( weightExtinguisher is not null )
            {
                return mapper.Map<WightExtuinguiserDto>( weightExtinguisher ); ;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.WeightNotFound );
            }
        }

        public async Task<WeightExtinguisherBase> CreateWeightExtinguisher( WeightExtinguisherBase weightExtinguisher )
        {
            var weight = mapper.Map<WeightExtinguisher>( weightExtinguisher );

            await repository.Add( weight );

            var result = mapper.Map<WeightExtinguisherBase>( weight );

            return result;
        }

        public async Task<WeightExtinguisherBase> UpdateWeightExtinguisher( Guid idWeightExtinguisher, WeightExtinguisherBase weightExtinguisherBase )
        {
            var weightExtinguisher = await repository.FindBy(p => p.WeightExtinguisherId == idWeightExtinguisher ).FirstOrDefaultAsync();

            if ( weightExtinguisher is not null )
            {
                //weightExtinguisherDb.IdDetalleServ = weightExtinguisher.IdDetalleServ;
                weightExtinguisher.WeightPound = weightExtinguisherBase.PesoXlibras;

                await repository.Update( weightExtinguisher );

                var result = mapper.Map<WeightExtinguisherBase>( weightExtinguisher );

                return result;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.WeightNotFound );
            }
        }


        public async Task<WightExtuinguiserDto> DeleteWeightExtinguisher( Guid idWeightExtinguisher )
        {
            var weightExtinguisher = await repository.FindBy( weight => weight.WeightExtinguisherId == idWeightExtinguisher ).FirstOrDefaultAsync();

            if ( weightExtinguisher is not null )
            {
                try
                {
                    await repository.Delete(weightExtinguisher);

                    var result = mapper.Map<WightExtuinguiserDto>(weightExtinguisher);

                    return result;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions( HandlingExtinguisherResources.RelatedWeight );
                }
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.WeightNotFound );
            }
        }

    }
}
