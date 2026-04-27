namespace HandlingExtinguishers.Contracts.Interfaces;

using HandlingExtinguishers.Models.Extinguishers;

public interface ITypeExtinguisherService
{
    Task<IEnumerable<TypeExtinguisherResponse>> SearchTypeExtinguisher();

    Task<TypeExtinguisherResponse> SearchTypeExtinguisherById( Guid typeExtinguisherId );

    Task<TypeExtinguisherResponse> CreateTypeExtinguisher( TypeExtinguisherRequest request );  
    
    Task<TypeExtinguisherResponse> UpdateTypeExtinguisher( Guid typeExtinguisherId, TypeExtinguisherRequest request );

    Task<TypeExtinguisherResponse> DeleteTypeExtinguisher( Guid typeExtinguisherId );
}
