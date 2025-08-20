
using DynamicsReporting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

[Route("api/[controller]")]
[ApiController]
public class DynamicsReportingController : ControllerBase
{


    private readonly IDynamicsReportingService _reportingService;

    public DynamicsReportingController(IDynamicsReportingService reportingService)
    {
        _reportingService = reportingService;
    }



    [HttpPost("GetDynamicsReportingData")]
    public async Task<IActionResult> GetDynamicsReportingDataAsync(int pageId, int currentPage, int pageSize)
    {
        var dynamicsReportingData = new PaginatedResult<ExpandoObject>();
        try
        {
            dynamicsReportingData = await _reportingService.GetDynamicsReportingDataAsync(pageId, currentPage, pageSize);

            if (dynamicsReportingData.Data.Count == 0)
            {
                dynamicsReportingData.StatusCode = 400;
                return StatusCode(400, dynamicsReportingData);
            }

            dynamicsReportingData.StatusCode = 200;
            return StatusCode(200, dynamicsReportingData);
        }
        catch
        {
            dynamicsReportingData.StatusCode = 500;
            return StatusCode(500, dynamicsReportingData);
        }


    }


}
