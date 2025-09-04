using System.Text.Json.Serialization;

namespace DynamicsReportingApp.Model.Authen
{

    public class BranchModel
    {
        [JsonPropertyName("branch_code")]
        public string BranchCode { get; set; }

        [JsonPropertyName("branch_name")]
        public string BranchName { get; set; }

        [JsonPropertyName("default_server")]
        public string DefaultServer { get; set; }
    }

  
    }
