using DynamicsReporting.ExternalService.Service.Group.Interface;
using DynamicsReporting.ExternalService.Utility;
using DynamicsReporting.Models;
using DynamicsReporting.Models.Base;
using DynamicsReporting.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;


namespace DynamicsReporting.API.Controllers.Group
{
    [Route("api/[controller]/")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ExternalService.Utility.Utility _utility;

        private readonly IGroupService _groupService;
        private readonly ILoggingRepository _logger;

        public GroupController(IGroupService groupService, ILoggingRepository loggingRepository, ExternalService.Utility.Utility utility)
        {
            _groupService = groupService;
            _logger = loggingRepository;
            _utility = utility;
        }



        // GET: api/Group/getAll?currentPage=1&pageSize=0
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync([FromQuery] int currentPage = 1, [FromQuery] int pageSize = 0)
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

        // GET: api/Group/{groupId}
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

        // GET: api/Group/{userID}

        // POST: api/Group/userGroupReports
        [HttpPost("userGroupReports")]
        public async Task<IActionResult> GetGroupReportByUserIdAsync([FromBody] ReqUserGroup req)
        {
            var responseData = new ResponseDataModel<GroupReportUseModel>();


            try
            {
                var model = await _groupService.GetGroupReportByUserIdAsync(req.userID, req.currentPage, req.pageSize);

                if (model != null)
                {
                  
                    responseData.ErrorCode = "0";
                    responseData.ErrorMessage = "Success";
                    responseData.Status = ResponseStatus.Success;
                    responseData.ErrorType = ResponseStatus.Success;
                    responseData.StatusCode = 200;

                    return StatusCode(HttpStatus.OK, responseData);
                }

                responseData.ErrorCode = "1";
                responseData.ErrorMessage = "No data found";
                responseData.Status = ResponseStatus.Failed;
                responseData.ErrorType = "DataNotFound";
                responseData.StatusCode = 404;

                return StatusCode(HttpStatus.NotFound, responseData);
            }
            catch (Exception ex)
            {
           

                string ErrMessage = "ErrorCode 500 " + ex.Message + " Internal server error: " + ex.Message;

                AddLogModel addLogModel = new AddLogModel();
                addLogModel.IPAddress = _utility.GetLocalIPAddress();
                addLogModel.HostName = _utility.GetHost();
                addLogModel.ErrorMessages = ErrMessage;
                addLogModel.FunctionName = "Authen";

                await _logger.AddLogAsync(addLogModel);

                responseData.ErrorCode = "500";
                responseData.ErrorMessage = ErrMessage;
                responseData.Status = ResponseStatus.Error;
                responseData.ErrorType = ResponseErrorType.Exception;
                responseData.StatusCode = 500;

                return StatusCode(500, responseData);


            }
        }



    }
}
