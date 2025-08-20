using DynamicsReporting.BusinessLogic.Service.User.Interface;
using DynamicsReporting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;


namespace DynamicsReporting.API.Controllers.User
{

    [ApiController]
    [Route("api/user/[controller]")]



    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user/getAll 
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync(int currentPage, int pageSize)
        {

            var result = new PaginatedResult<UserModel>();
            try
            {
                result = await _userService.GetAllAsync(currentPage, pageSize);

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

        // GET: api/userName/{userName}
        [HttpGet("userId/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _userService.GetByUserNameAsync(userName);
            if (user == null) return NotFound();

            return Ok(user);
        }



        // GET: api/user/{id}/GroupReport
        [HttpGet("groupReport/{userId}")]
        public async Task<IActionResult> GroupReportByUserIdAsync(int userId, int currentPage, int pageSize)
        {

            var result = new PaginatedResult<UserGroupReportModel>();
            try
            {
                result = await _userService.GroupReportByUserIdAsync(userId, currentPage, pageSize);

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
