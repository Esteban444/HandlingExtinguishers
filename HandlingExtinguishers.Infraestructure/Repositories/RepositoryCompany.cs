﻿using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructure.Repositories
{
    public class RepositoryCompany : BaseRepository<Company>, IRepositoryCompany
    {
        public RepositoryCompany(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
