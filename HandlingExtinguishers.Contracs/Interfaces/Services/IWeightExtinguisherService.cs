namespace HandlingExtinguishers.Contracts.Interfaces.Services; 

using HandlingExtinguishers.Models.Extinguishers;

public interface IWeightExtinguisherService
{
    Task<IEnumerable<WightExtinguisherRequest>> SearchWeightExtinguishers();

    Task<WightExtinguisherRequest> SearchWeightExtinguisherById( Guid weightExtinguisherId );

    Task<WightExtinguisherRequest> CreateWeightExtinguisher( WightExtinguisherRequest weightExtinguisher );

    Task<WightExtinguisherRequest> UpdateWeightExtinguisher( Guid weightExtinguisherId, WightExtinguisherRequest weightExtinguisher );

    Task<WightExtinguisherRequest> DeleteWeightExtinguisher( Guid weightExtinguisherId );
}
