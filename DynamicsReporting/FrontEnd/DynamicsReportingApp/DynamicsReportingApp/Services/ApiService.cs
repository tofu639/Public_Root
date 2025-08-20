using DynamicsReporting.Models.Authen;
using Newtonsoft.Json;




namespace DynamicsReportingApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;
        private string AuthenGetBranch = "GetBranch";
        private string AuthenGetBranchByBranchCode = "GetBranchByBranchCode/{branchCode}";
        private string Authen = "Authen";

        public ApiService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        //private readonly HttpClient _httpClient;
        //public ApiService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        public async Task<List<BranchModel>> GetBranchAllAsync()
        {
            var apiUrl = _config.GetValue<string>("ApiBaseUrl") + AuthenGetBranch;
            var response = await _http.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<BranchModel>>(json)!;
        }





    }
}
