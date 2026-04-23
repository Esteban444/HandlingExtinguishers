using HandlingExtinguishers.Models.Extinguishers;

namespace HandlingExtinguishers.Contracts.Interfaces.Services;


public interface ITypeExtinguisherService
{
    Task<IEnumerable<TypeExtinguisherResponse>> SearchTypeExtinguisher();

    Task<TypeExtinguisherResponse> SearchTypeExtinguisherById( Guid typeExtinguisherId );

    Task<TypeExtinguisherResponse> CreateTypeExtinguisher( TypeExtinguisherRequest request );  
    
    Task<TypeExtinguisherResponse> UpdateTypeExtinguisher( Guid typeExtinguisherId, TypeExtinguisherRequest request);

    Task<TypeExtinguisherResponse> DeleteTypeExtinguisher( Guid typeExtinguisherId );
}
