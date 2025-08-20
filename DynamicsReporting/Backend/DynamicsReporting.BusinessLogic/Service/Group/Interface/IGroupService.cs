using DynamicsReporting.Models;

namespace DynamicsReporting.BusinessLogic.Service.Group.Interface
{
    public interface IGroupService
    {
        Task<PaginatedResult<GroupModel>> GetAllAsync(int currentPage, int pageSize);
        Task<PaginatedResult<GroupReportModel>> GetReportByGroupIdAsync(int groupId, int currentPage, int pageSize);
    }
}