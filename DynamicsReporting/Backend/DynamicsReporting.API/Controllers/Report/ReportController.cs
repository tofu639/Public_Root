using DynamicsReporting.ExternalService.Service.Report.Interface;
using DynamicsReporting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace DynamicsReporting.API.Controllers.Report
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IReportService _reportingService;

        public ReportController(IReportService reportingService)
        {
            _reportingService = reportingService;
        }



        [HttpPost("getAll")]
        public async Task<IActionResult> GetDynamicsReportingDataAsync(int currentPage, int pageSize)
        {

            var result = new PaginatedResult<ReportModel>();
            try
            {
                result = await _reportingService.GetAllAsync(currentPage, pageSize);

                if (result.Data.Count == 0)
                {
                    result.StatusCode = 400;
                    return StatusCode(400, result);
                }

                result.StatusCode = 200;
                return StatusCode(200, result);
            }
            catch
            {
                result.StatusCode = 500;
                return StatusCode(500, result);
            }
        }


        [HttpPost("reportId/{reportId}")]
        public async Task<IActionResult> GetReportByIdAsync(int reportId, int currentPage, int pageSize)
        {

            var result = new PaginatedResult<ReportModel>();
            try
            {
                result = await _reportingService.GetReportByIdAsync(reportId, currentPage, pageSize);

                if (result.Data.Count == 0)
                {
                    result.StatusCode = 400;
                    return StatusCode(400, result);
                }

                result.StatusCode = 200;
                return StatusCode(200, result);
            }
            catch
            {
                result.StatusCode = 500;
                return StatusCode(500, result);
            }


        }






    }
}
