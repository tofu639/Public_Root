using DynamicsReportingApp.Model.Authen;
using System.Text.Json;
namespace DynamicsReportingApp.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;

    private string AuthenGetBranch = "/Authen/GetBranch";
    private string AuthenGetBranchByBranchCode = "Authen/GetBranchByBranchCode/{branchCode}";
    private string Authen = "/Authen/Authen";

    public ApiService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }

    public async Task<List<BranchModel>> GetBranchAsync()
    {
        var apiUrl = _config.GetValue<string>("ApiBaseUrl") + AuthenGetBranch;
        var response = await _http.GetFromJsonAsync<ResponseDataModel<List<BranchModel>>>(apiUrl);
        return response?.Data ?? new List<BranchModel>();
    }



    public async Task<ResponseDataModel<AuthenResponseModel>> AuthenAsync(AuthenRequestModel model)
    {
        var apiUrl = _config.GetValue<string>("ApiBaseUrl") + Authen;
        var response = await _http.PostAsJsonAsync(apiUrl, model);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<ResponseDataModel<AuthenResponseModel>>();
        return result ?? new ResponseDataModel<AuthenResponseModel>();
    }



}
