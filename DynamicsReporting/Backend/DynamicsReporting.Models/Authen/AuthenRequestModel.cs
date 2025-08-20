

using System.ComponentModel.DataAnnotations;

namespace DynamicsReporting.Models.Authen
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


    public class BranchModel
    {
        public string branch_code { get; set; }
        public string branch_name { get; set; }

        public string default_server { get; set; }
    }




}
