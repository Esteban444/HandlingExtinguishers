﻿using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class RepositoryInventory : BaseRepository<Inventory>, IRepositoryInventory
    {
        public RepositoryInventory(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
