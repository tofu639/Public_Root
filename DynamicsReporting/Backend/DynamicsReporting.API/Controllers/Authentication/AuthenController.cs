using DynamicsReporting.BusinessLogic.Service.Authentication.Interface;
using DynamicsReporting.Models.Authen;
using DynamicsReporting.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace DynamicsReporting.API.Controllers.Authentication
{



    [Route("/api/[controller]/")]

    [ApiController]


    public class AuthenController : ControllerBase
    {

        private readonly IAuthenService _authenService;
        private readonly ILoggingRepository _logger;
        private readonly ExternalService.Utility _utility;



        public AuthenController(IAuthenService authenService, ILoggingRepository loggingRepository, ExternalService.Utility utility)
        {
            _authenService = authenService;
            _logger = loggingRepository;
            _utility = utility;
        }






        [HttpGet("GetBranch")]
        public async Task<IActionResult> GetBranch()
        {
            var responseData = new ResponseDataModel<List<BranchModel>>();

            try
            {
                var listBranchModel = await _authenService.GetBranchAsync();

                if (listBranchModel != null && listBranchModel.Any())
                {
                    responseData.Data = listBranchModel;
                    responseData.ErrorCode = "0";
                    responseData.ErrorMessage = "Success";
                    responseData.Status = ResponseStatus.Success;
                    responseData.ErrorType = ResponseStatus.Success;
                    responseData.StatusCode = 200;


                    return StatusCode(HttpStatus.OK, new { responseData });
                }

                responseData.ErrorCode = "1";
                responseData.ErrorMessage = "No data found";
                responseData.Status = ResponseStatus.Failed;
                responseData.ErrorType = "DataNotFound";
                responseData.StatusCode = 404;
                return StatusCode(HttpStatus.NotFound, new { responseData });

            }
            catch (Exception ex)
            {
                AddLogModel addLogModel = new AddLogModel();
                addLogModel.IPAddress = _utility.GetLocalIPAddress();
                addLogModel.HostName = _utility.GetHost();
                addLogModel.ErrorMessages = "ErrorCode 500 " + ex.Message;
                addLogModel.FunctionName = "GetBranchALL";

                _logger.AddLogAsync(addLogModel);

                responseData.ErrorCode = "500";
                responseData.ErrorMessage = ex.Message;
                responseData.Status = ResponseStatus.Error;
                responseData.ErrorType = ResponseErrorType.Exception;
                responseData.StatusCode = 500;

                return StatusCode(500, responseData);
            }



        }



        [HttpGet("GetBranchByBranchCode/")]
        public async Task<IActionResult> GetBranchByBranchCodeAsync([FromQuery] string branchCode)
        {


            var responseData = new ResponseDataModel<BranchModel>();

            try
            {
                var model = await _authenService.GetBranchByBranchCodeAsync(branchCode);

                if (model != null)
                {
                    responseData.Data = model;
                    responseData.ErrorCode = "0";
                    responseData.ErrorMessage = "Success";
                    responseData.Status = ResponseStatus.Success;
                    responseData.ErrorType = ResponseStatus.Success;
                    responseData.StatusCode = 200;

                    return Ok(responseData);
                }

                responseData.ErrorCode = "1";
                responseData.ErrorMessage = "No data found";
                responseData.Status = ResponseStatus.Failed;
                responseData.ErrorType = "DataNotFound";
                responseData.StatusCode = 404;

                return NotFound(responseData);
            }
            catch (Exception ex)
            {
                AddLogModel addLogModel = new AddLogModel();
                addLogModel.IPAddress = _utility.GetLocalIPAddress();
                addLogModel.HostName = _utility.GetHost();
                addLogModel.ErrorMessages = "ErrorCode 500 " + ex.Message;
                addLogModel.FunctionName = "GetBranchALL";

                _logger.AddLogAsync(addLogModel);

                responseData.ErrorCode = "500";
                responseData.ErrorMessage = ex.Message;
                responseData.Status = ResponseStatus.Error;
                responseData.ErrorType = ResponseErrorType.Exception;
                responseData.StatusCode = 500;

                return StatusCode(500, responseData);
            }



        }


        [HttpPost("Authen")]
        public async Task<IActionResult> Authen([FromBody] AuthenRequestModel authen)
        {


            var responseData = new ResponseDataModel<AuthenResponseModel>();

            try
            {
                var Model = await _authenService.AuthenAsync(authen);
                if (Model != null)
                {
                    responseData.Data = Model;
                    responseData.ErrorCode = "0";
                    responseData.ErrorMessage = "Success";
                    responseData.Status = ResponseStatus.Success;
                    responseData.ErrorType = ResponseStatus.Success;
                    responseData.StatusCode = 200;

                    return Ok(responseData);
                }

                responseData.ErrorCode = "1";
                responseData.ErrorMessage = "No data found";
                responseData.Status = ResponseStatus.Failed;
                responseData.ErrorType = "DataNotFound";
                responseData.StatusCode = 404;

                return NotFound(responseData);


            }
            catch (Exception ex)
            {
                string ErrMessage = "ErrorCode 500 " + ex.Message + " | User : " + authen.Username + "| BranchCode :" + authen.BranchCode;

                AddLogModel addLogModel = new AddLogModel();
                addLogModel.IPAddress = _utility.GetLocalIPAddress();
                addLogModel.HostName = _utility.GetHost();
                addLogModel.ErrorMessages = ErrMessage;
                addLogModel.FunctionName = "Authen";

                _logger.AddLogAsync(addLogModel);

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
