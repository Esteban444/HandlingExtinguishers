using AutoMapper;
using HandlingExtinguisher.Contracts.Interfaces.Services;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Data.Entity;
using System.Net;

namespace HandlingFireExtinguisher.Core.Services
{
    public class ServicioCliente : IServicieClient
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
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El cliente que solicita no existe en la base de datos" });
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
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El cliente que desea actualizar no existe en la base de datos" });
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
                    throw new HandlingExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El cliente tiene relacion con un servicio no se puede borrar" });
                }
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El cliente no existe en la base de datos" });
            }
        }
    }
}
