using DynamicsReportingApp.Model;
using DynamicsReportingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace DynamicsReportingApp.Controllers
{
    public class AuthenController : Controller
    {


        private readonly ApiService _apiService;

        public AuthenController(ApiService apiService)
        {
            _apiService = apiService;
        }


        public IActionResult Index { get; }

        public async Task<ActionResult> Login()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBranchAll()
        {
            var branches = await _apiService.GetBranchAllAsync();

            // ใช้ SelectList สำหรับ dropdown
            ViewBag.Branches = new SelectList(branches, "BranchId", "BranchName");

            // ส่งไป view
            return View(branches); // จะไปหา Views/Branch/GetBranchAll.cshtml
        }


    }
}
