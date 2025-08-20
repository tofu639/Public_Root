using Microsoft.AspNetCore.Mvc;

namespace DynamicsReportingApp.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
