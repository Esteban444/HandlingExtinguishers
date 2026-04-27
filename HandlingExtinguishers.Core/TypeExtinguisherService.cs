namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
#endregion

public class TypeExtinguisherService( IBaseRepository<TypeExtinguisher> repository, IMapper mapper ) : ITypeExtinguisherService
{
    private readonly IBaseRepository<TypeExtinguisher> repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<TypeExtinguisherResponse>> SearchTypeExtinguisher()
    {
        var result = await repository.GetAll().ToListAsync();

        var response = mapper.Map<IEnumerable<TypeExtinguisherResponse>>( result );

        return response;
    }

    public async Task<TypeExtinguisherResponse> SearchTypeExtinguisherById( Guid typeExtinguisherId )
    {
        var result = await repository.FindBy( type => type.TypeExtinguisherId == typeExtinguisherId ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<TypeExtinguisherResponse>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherNotFound );
        }
    }

    public async Task<TypeExtinguisherResponse> CreateTypeExtinguisher( TypeExtinguisherRequest request )
    {
        var result = mapper.Map<TypeExtinguisher>( request );

        await repository.Add( result );   

        var response = mapper.Map<TypeExtinguisherResponse>( result );

        return response;
    }

    public async Task<TypeExtinguisherResponse> UpdateTypeExtinguisher( Guid id, TypeExtinguisherRequest request )
    {
        var result = await repository.FindBy( type => type.TypeExtinguisherId == id).FirstOrDefaultAsync();

        if ( result is not null )
        {
            //typeInDb.IdDetalleServ = request.IdDetalleServ;
            result.TypeExtinguisherId = request.TypeExtinguisherId;

            await repository.Update( result );

            var response = mapper.Map<TypeExtinguisherResponse>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherNotFound );
        }
    }


    public async Task<TypeExtinguisherResponse> DeleteTypeExtinguisher( Guid typeExtinguisherId )
    {
        var result = await repository.FindBy( type => type.TypeExtinguisherId == typeExtinguisherId).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repository.Delete( result );

                var response = mapper.Map<TypeExtinguisherResponse>( result );

                return response;
            }
            catch ( Exception )
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherRelated );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherNotFound );
        }
    }

}
