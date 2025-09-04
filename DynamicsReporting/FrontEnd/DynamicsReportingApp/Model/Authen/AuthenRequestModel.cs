using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DynamicsReportingApp.Model.Authen
{
    public class AuthenRequestModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string Username { get; set; } = "Test";//string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
        public string Password { get; set; } = "TEST"; // string.Empty;

        [Required(ErrorMessage = "Branch code is required")]
        [StringLength(50, ErrorMessage = "Branch code cannot exceed 50 characters")]
        public string BranchCode { get; set; } = "003";// string.Empty;

    }



}
