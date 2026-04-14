using HandlingExtinguishers.Models.Extinguishers;

namespace HandlingExtinguishers.Contracts.Interfaces.Services 
{
    public interface IWeightExtinguisherService
    {
        Task<IEnumerable<WightExtuinguiserDto>> SearchWeightExtinguishers();
        Task<WightExtuinguiserDto> SearchWeightExtinguisherById( Guid idWeightExtinguisher );
        Task<WeightExtinguisherBase> CreateWeightExtinguisher( WeightExtinguisherBase weightExtinguisher );
        Task<WeightExtinguisherBase> UpdateWeightExtinguisher( Guid idWeightExtinguisher, WeightExtinguisherBase weightExtinguisher );
        Task<WightExtuinguiserDto> DeleteWeightExtinguisher( Guid idWeightExtinguisher );
    }
}
