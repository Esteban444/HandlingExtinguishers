using AutoMapper;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Models;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingFireExtinguisher.Core.Services
{
    public class ServicioCliente : IClientService
    {
        private readonly IRepositoryClient _repository;
        private readonly IMapper _mapper;
        public ServicioCliente(IRepositoryClient repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetClients(FilterClient filter)
        {
            var clients = await _repository.GetAll().ToListAsync();
            if (filter.Name != null)
            {
                clients = clients.Where(x => x.Name!.ToLower().Contains(filter.Name.ToLower())).ToList();
            }

            if (filter.LastName != null)
            {
                clients = clients.Where(x => x.LasName!.ToLower().Contains(filter.LastName.ToLower())).ToList();
            }
            var response = _mapper.Map<IEnumerable<ClientDto>>(clients);
            return response;
        }

        public async Task<ClientDto> GetClient(Guid clientId)
        {
            var client = await _repository.FindBy(c => c.Id == clientId).FirstOrDefaultAsync();
            if (client != null)
            {
                return _mapper.Map<ClientDto>(client);
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.ClientNotFound );
            }
        }

        public async Task<BaseClient> CreateClient(BaseClient clienteb)
        {
            var client = _mapper.Map<Client>(clienteb);
            await _repository.Add(client);
            var response = _mapper.Map<BaseClient>(client);
            return response;

        }

        public async Task<BaseClient> UpdateClient(Guid clientId, BaseClient client)
        {
            var result = await _repository.FindBy(c => c.Id == clientId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.DocumentClient = client.DocumentClient;
                result.Name = client.Name;
                result.LasName = client.LasName;
                result.Description = client.Description;
                result.Address = client.Address;
                result.Phone = client.Phone;
                result.Email = client.Email;
                result.Nit = client.Nit;

                await _repository.Update(result);
                var response = _mapper.Map<BaseClient>(result);
                return response;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.ClientNotFound );
            }
        }

        public async Task<ClientDto> DeleteClient(Guid clientId)
        {
            var clientebd = await _repository.FindBy(c => c.Id == clientId).FirstOrDefaultAsync();
            if (clientebd != null)
            {
                try
                {
                    await _repository.Delete(clientebd);
                    var clienteE = _mapper.Map<ClientDto>(clientebd);
                    return clienteE;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions( HandlingExtinguisherResources.RelatedClient );
                }
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.ClientNotFound );
            }
        }
    }
}
