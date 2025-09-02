using DynamicsReporting.Models;

namespace DynamicsReporting.ExternalService.Service.Group.Interface
{
    public interface IGroupService
    {
        Task<PaginatedResult<GroupModel>> GetAllAsync(int currentPage, int pageSize);
        Task<PaginatedResult<GroupReportModel>> GetReportByGroupIdAsync(int groupId, int currentPage, int pageSize);

        Task<PaginatedResult<GroupReportUseModel>> GetGroupReportByUserIdAsync(string userID, int currentPage, int pageSize);

    }
}