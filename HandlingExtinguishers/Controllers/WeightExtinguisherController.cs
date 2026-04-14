using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Extinguishers;
using ManagementFireEstinguisher.Dto.Extinguishers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class WeightExtinguisherController : ControllerBase
    {
        private readonly IWeightExtinguisherService serviceWeightExtinguisher;
        private readonly IValidator<WeightExtinguisherBase> _validator;

        public WeightExtinguisherController( IWeightExtinguisherService serviceWeightExtinguisher, IValidator<WeightExtinguisherBase> validator )
        {
            this.serviceWeightExtinguisher = serviceWeightExtinguisher;
            _validator = validator;
        }

        [HttpGet("searchs")]
        public async Task<IActionResult> SearchWeightExtinguishers() 
        {
            var response = await serviceWeightExtinguisher.SearchWeightExtinguishers();

            return Ok(response);
        }

        [HttpGet("search-by/{idWeightExtinguisher}")]
        public async Task<IActionResult> SearchWeightExtinguisherById(Guid idWeightExtinguisher )
        {
            var response = await serviceWeightExtinguisher.SearchWeightExtinguisherById( idWeightExtinguisher );

            return Ok(response);
        }

        [HttpPost("create-weight-extinguisher")]
        public async Task<IActionResult> CreateWeightExtinguisher( WeightExtinguisherBase weightExtinguisher )
        {
            var Validation = _validator.Validate( weightExtinguisher );

            if ( !Validation.IsValid )
            {
                var errors = Validation.Errors.Select( error => error.ErrorMessage );

                return BadRequest(new RespuestaPesoExtintor { Errors = errors });
            }
            else
            {
                var response = await serviceWeightExtinguisher.CreateWeightExtinguisher( weightExtinguisher );

                return Ok(response);
            }
        }

        [HttpPut("update-weight-extinguisher-by/{idWeightExtinguisher}")]
        public async Task<IActionResult> UpdateWeightExtinguisher( Guid idWeightExtinguisher, WeightExtinguisherBase weightExtinguisher )
        {
            var Validation = _validator.Validate( weightExtinguisher );

            if ( !Validation.IsValid )
            {
                var errors = Validation.Errors.Select( error => error.ErrorMessage );

                return BadRequest( new RespuestaPesoExtintor { Errors = errors } );
            }
            else
            {
                var response = await serviceWeightExtinguisher.UpdateWeightExtinguisher( idWeightExtinguisher, weightExtinguisher );

                return Ok( response );
            }
        }

        [HttpDelete("delete-weight-extinguisher-by/{idWeightExtinguisher}")]
        public async Task<IActionResult> DeletedWeightEstinguisher( Guid idWeightExtinguisher )
        {
            var response = await serviceWeightExtinguisher.DeleteWeightExtinguisher( idWeightExtinguisher );

            return Ok( response );

        }
    }
}
