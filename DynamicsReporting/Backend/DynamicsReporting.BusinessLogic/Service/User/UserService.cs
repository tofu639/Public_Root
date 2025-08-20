using DynamicsReporting.BusinessLogic.Service.User.Interface;
using DynamicsReporting.Models;

namespace DynamicsReporting.BusinessLogic.Service.User
{


    using DynamicsReporting.DataAccess.Repository.User.Interface;


    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<PaginatedResult<UserModel>> GetAllAsync(int currentPage, int pageSize)
        {
            return await _userRepository.GetAllAsync(currentPage, pageSize);
        }

        public async Task<UserModel> GetByUserNameAsync(string userName)
        {
            return await _userRepository.GetByUserNameAsync(userName);
        }

        public async Task<PaginatedResult<UserGroupReportModel>> GroupReportByUserIdAsync(int userId, int currentPage, int pageSize)
        {
            return await _userRepository.GroupReportByUserIdAsync(userId, currentPage, pageSize);
        }


    }





}
