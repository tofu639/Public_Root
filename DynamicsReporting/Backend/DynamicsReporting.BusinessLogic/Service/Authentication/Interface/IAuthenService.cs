using DynamicsReporting.Models.Authen;

namespace DynamicsReporting.ExternalService.Service.Authentication.Interface
{
    public interface IAuthenService
    {
        Task<List<BranchModel>> GetBranchAsync();
        Task<BranchModel> GetBranchByBranchCodeAsync(string branchCode);    
        Task<AuthenResponseModel> AuthenAsync(AuthenRequestModel authen);
 
    }
}