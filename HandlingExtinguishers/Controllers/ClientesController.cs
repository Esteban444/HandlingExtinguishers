using FluentValidation;
using HandlinExtinguisher.Dto.Clients;
using HandlingExtinguisher.Contracts.Interfaces.Services;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Dto;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IServicieClient _serviceClient;
        private readonly IValidator<BaseClient> _validator;
        public ClientesController(IServicieClient client, IValidator<BaseClient> validator)
        {
            _serviceClient = client;
            _validator = validator;
        }

        [HttpGet("clients")]
        public async Task<IActionResult> Searchs([FromQuery] FilterClient filter)
        {
            var clients = await _serviceClient.GetClients(filter);
            var response = new OperationResult<IEnumerable<ClientDto>>(clients);
            return Ok(response);
        }

        [HttpGet("search-by/{clientId}")]
        public async Task<IActionResult> Search(Guid clientId)
        {
            var client = await _serviceClient.GetClient(clientId);
            var response = new OperationResult<ClientDto>(client);
            return Ok(response);
        }

        [HttpPost("client")]
        public async Task<IActionResult> Create(BaseClient client)
        {
            var Validation = _validator.Validate(client);
            if (!Validation.IsValid)
            {
                var errors = Validation.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new ResponseClient { Errors = errors });
            }
            else
            {
                await _serviceClient.CreateClient(client);
                var response = new OperationResult<BaseClient>(client);
                return Ok(response);
            }
        }

        [HttpPut("update/{clientId}")]
        public async Task<IActionResult> UpdateClient(Guid clientId, BaseClient request)
        {
            var Validation = _validator.Validate(request);
            if (!Validation.IsValid)
            {
                var errors = Validation.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new ResponseClient { Errors = errors });
            }
            else
            {
                var result = await _serviceClient.UpdateClient(clientId, request);
                var response = new OperationResult<BaseClient>(result);
                return Ok(response);
            }
        }

        [HttpDelete("delete/{clientId}")]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            var result = await _serviceClient.DeleteClient(clientId);
            var response = new OperationResult<ClientDto>(result);
            return Ok(response);

        }
    }
}
