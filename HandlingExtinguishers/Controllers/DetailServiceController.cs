using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.Controllers
{
    [Route("api/detail-service")]
    [ApiController]
    [Authorize]
    public class DetailServiceController( IDetailService detailService ) : ControllerBase
    {
        private readonly IDetailService detailService = detailService;

        [HttpGet("search")]
        public async Task<IActionResult> SearchDetails( [FromQuery] FilterDetailService filter )
        {
            var response = await detailService.SearchDetailsService( filter );

            return Ok( response );
        }

        [HttpGet("search-by/{idDetail}")]
        public async Task<IActionResult> GetDetailById( Guid idDetail )
        {
            var response = await detailService.GetDetailServiceById( idDetail );

            return Ok( response );
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDetail( DetalleServicioBase request )
        {
            var response = await detailService.CreateDetailService( request );

            return Ok( response );
        }

        [HttpPut("update-by/{idDetail}")]
        public async Task<IActionResult> UpdateDetail( Guid idDetail, DetalleServicioBase request )
        {
            var response = await detailService.UpdateDetailService( idDetail, request );

            return Ok( response );
        }

        [HttpDelete("delete-by/{idDetail}")]
        public async Task<IActionResult> DeleteDetail( Guid idDetail )
        {
            var response = await detailService.DeleteDetailService( idDetail );

            return Ok( response );

        }

    }
}
