using DynamicsReportingApp.Model.Authen;



namespace DynamicsReportingApp.Services
{
    public interface IApiService
    {
  


        Task<List<BranchModel>> GetBranchAsync();
        Task<ResponseDataModel<AuthenResponseModel>> AuthenAsync(AuthenRequestModel model);

    }

}