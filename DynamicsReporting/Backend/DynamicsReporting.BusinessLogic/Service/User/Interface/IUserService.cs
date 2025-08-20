using DynamicsReporting.Models;
namespace DynamicsReporting.BusinessLogic.Service.User.Interface
{
    public interface IUserService
    {
        Task<PaginatedResult<UserModel>> GetAllAsync(int currentPage, int pageSize);
        Task<UserModel> GetByUserNameAsync(string userName);
        Task<PaginatedResult<UserGroupReportModel>> GroupReportByUserIdAsync(int userId, int currentPage, int pageSize);
    }
}