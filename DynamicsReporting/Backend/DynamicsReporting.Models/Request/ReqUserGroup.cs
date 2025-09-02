using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsReporting.Models.Request
{
    public class ReqUserGroup
    {
        [Required(ErrorMessage = "UserID is required")]
        public string userID { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }



    }
}
