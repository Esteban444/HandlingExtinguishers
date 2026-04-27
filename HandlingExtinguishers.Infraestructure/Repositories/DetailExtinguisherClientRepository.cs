namespace HandlingExtinguishers.Infraestructure.Repositories;

#region Usings
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Models.Models;
#endregion

public class DetailExtinguisherClientRepository( HandlingExtinguisherContext context ) : 
                                                 BaseRepository<DetailExtinguisherClient>(context), IDetailExtinguisherClientRepository
{
}
