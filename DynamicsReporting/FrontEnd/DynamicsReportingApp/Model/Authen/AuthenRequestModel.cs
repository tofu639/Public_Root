using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DynamicsReportingApp.Model.Authen
{
    public class AuthenRequestModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Branch is required")]
        public string BranchCode { get; set; }

        public IEnumerable<SelectListItem> Branches { get; set; } = new List<SelectListItem>();
    }


}


//    public class BranchModel
//    {
//        [JsonPropertyName("BranchCode")]
//        public string BranchCode { get; set; }
//        [JsonPropertyName("BranchName")]
//        public string BranchName { get; set; }
//        [JsonPropertyName("DefaultServer")]
//        public string DefaultServer { get; set; }
//    }

//}
