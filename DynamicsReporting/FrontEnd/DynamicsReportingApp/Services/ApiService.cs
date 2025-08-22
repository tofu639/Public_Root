using DynamicsReportingApp.Model.Authen;
using System.Collections.Generic;
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
        ResponseDataModel<List<BranchModel>> response = new ResponseDataModel<List<BranchModel>>();
        List<BranchModel> branches = new List<BranchModel>();

        try
        {
            var apiUrl = _config.GetValue<string>("ApiBaseUrl") + AuthenGetBranch;



            response = await _http.GetFromJsonAsync<ResponseDataModel<List<BranchModel>>>(apiUrl);

            branches = response.Data;

        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;


            throw;
        }

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
