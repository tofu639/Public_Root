using DynamicsReporting.Models;

namespace DynamicsReporting.DataAccess.Repository.Group.Interface
{
    public interface IGroupRepository
    {

        Task<PaginatedResult<GroupReportModel>> GetReportByGroupIdAsync(int groupId, int currentPage, int pageSize);
        Task<PaginatedResult<GroupModel>> GetAllAsync(int currentPage, int pageSize);       



    }
}