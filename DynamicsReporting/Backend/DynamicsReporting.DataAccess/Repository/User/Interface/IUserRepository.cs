using DynamicsReporting.Models;

namespace DynamicsReporting.DataAccess.Repository.User.Interface
{
    public interface IUserRepository
    {
        Task<PaginatedResult<UserModel>> GetAllAsync(int currentPage, int pageSize);
        Task<UserModel> GetByUserNameAsync(string userName);
        Task<PaginatedResult<UserGroupReportModel>> GroupReportByUserIdAsync(int userId, int currentPage, int pageSize);
    }
}
