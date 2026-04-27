namespace HandlingExtinguishers.Contracts.Interfaces; 

using HandlingExtinguishers.Models.Extinguishers;

public interface IWeightExtinguisherService
{
    Task<IEnumerable<WightExtinguisherRequest>> SearchWeightExtinguishers();

    Task<WightExtinguisherRequest> SearchWeightExtinguisherById( Guid weightExtinguisherId );

    Task<WightExtinguisherRequest> CreateWeightExtinguisher( WightExtinguisherRequest request );

    Task<WightExtinguisherRequest> UpdateWeightExtinguisher( Guid weightExtinguisherId, WightExtinguisherRequest request ); 

    Task<WightExtinguisherRequest> DeleteWeightExtinguisher( Guid weightExtinguisherId );
}
