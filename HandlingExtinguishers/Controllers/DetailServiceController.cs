namespace HandlingExtinguishers.Controllers;

#region Usings
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
# endregion

[Route("api/detail-service")]
[ApiController]
[Authorize]
public class DetailServiceController( IDetailServiceQueryService detailServiceQuery,
                                      IDetailServiceCommandService detailCommandService ) : ControllerBase
{
    private readonly IDetailServiceQueryService detailServiceQuery = detailServiceQuery;
    private readonly IDetailServiceCommandService detailService = detailCommandService;

    [HttpGet("search")]
    public async Task<IActionResult> SearchDetails( [FromQuery] FilterDetailService filter )
    {
        var response = await detailServiceQuery.SearchDetailsService( filter );

        return Ok( response );
    }

    [HttpGet("search-by/{idDetail}")]
    public async Task<IActionResult> GetDetailById( Guid idDetail )
    {
        var response = await detailServiceQuery.GetDetailServiceById( idDetail );

        return Ok( response );
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateDetail( DetailServiceRequest request )
    {
        var response = await detailService.CreateDetailService( request );

        return Ok( response );
    }

    [HttpPut("update-by/{idDetail}")]
    public async Task<IActionResult> UpdateDetail( Guid idDetail, DetailServiceRequest request )
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
