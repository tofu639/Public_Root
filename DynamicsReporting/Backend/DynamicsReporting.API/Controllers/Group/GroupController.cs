using DynamicsReporting.BusinessLogic.Service.Group.Interface;
using DynamicsReporting.Models;
using Microsoft.AspNetCore.Mvc;


namespace DynamicsReporting.API.Controllers.Group
{
    [Route("api/[controller]/")]
    [ApiController]
    public class GroupController : ControllerBase
    {


        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        // GET: api/Group/GetAll 
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync(int currentPage, int pageSize)
        {

            var result = new PaginatedResult<GroupModel>();
            try
            {
                result = await _groupService.GetAllAsync(currentPage, pageSize);

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

        // GET: api/userId/{groupId}
        [HttpGet("groupId/{groupId}")]
        public async Task<IActionResult> GetReportByGroupIdAsync(int groupId, int currentPage, int pageSize)
        {
            var result = new PaginatedResult<GroupReportModel>();
            try
            {
                result = await _groupService.GetReportByGroupIdAsync(groupId, currentPage, pageSize);

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
