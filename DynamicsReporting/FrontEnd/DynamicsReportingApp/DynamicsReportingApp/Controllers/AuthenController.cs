using DynamicsReportingApp.Model.Authen;
using DynamicsReportingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AuthenController : Controller
{
    private readonly IApiService _apiService;

    public AuthenController(IApiService apiService)
    {
        _apiService = apiService;
    }


    [HttpGet]
    public async Task<IActionResult> Login()
    {
        var branches = await _apiService.GetBranchAsync();
        ViewBag.Branches = new SelectList(branches, "BranchCode", "BranchName");

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var branches = await _apiService.GetBranchAsync();
        ViewBag.Branches = new SelectList(branches, "BranchCode", "BranchName");

        return View("Login"); // บังคับให้ใช้ Login.cshtml แทน
    }

     
    [HttpPost]
    public async Task<IActionResult> Login(AuthenRequestModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var response = await _apiService.AuthenAsync(model);
        if (response?.Data != null && response.Data.IsAuthenticated)
        {
            HttpContext.Session.SetString("BranchCode", response.Data.BranchCode ?? "");
            HttpContext.Session.SetString("BranchName", response.Data.BranchName ?? "");
            HttpContext.Session.SetString("DefaultServer", response.Data.DefaultServer ?? "");

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "User หรือ Password ไม่ถูกต้อง");
        var branches = await _apiService.GetBranchAsync();
        ViewBag.Branches = new SelectList(branches, "BranchCode", "BranchName");

        return View("Login", model);
    }
}
