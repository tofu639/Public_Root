using DocumentFormat.OpenXml.EMMA;
using DynamicsReportingApp.Model.Authen;
using DynamicsReportingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AuthenController : Controller
{
    private readonly IApiService _apiService;
    private const string SESSION_BRANCH_CODE = "BranchCode";
    private const string SESSION_BRANCH_NAME = "BranchName";
    private const string SESSION_DEFAULT_SERVER = "DefaultServer";
    public AuthenController(IApiService apiService)
    {
        _apiService = apiService;
    }


    [HttpGet]
    public async Task<IActionResult> Login()
    {
        // var responseDataModel = new ResponseDataModel<List<BranchModel>>();

        var branches = await _apiService.GetBranchAsync();

        var model = new AuthenRequestModel
        {
            Branches = branches.Select(static b => new SelectListItem
            {
                Value = b.BranchCode,
                Text = b.BranchName
            })
        };

        return View(model);


    }

    [HttpGet]
    public IActionResult Index()
    {
        return RedirectToAction(nameof(Login));
    }


    private async Task PopulateBranches(AuthenRequestModel model)
    {
        var branches = await _apiService.GetBranchAsync();
        model.Branches = branches.Select(b => new SelectListItem
        {
            Value = b.BranchCode,
            Text = b.BranchName
        });
    }



    [HttpPost]
    public async Task<IActionResult> Login(AuthenRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            await PopulateBranches(model);
            return View(model);
        }

        try
        {
            var response = await _apiService.AuthenAsync(model);
            if (response?.Data != null && response.Data.IsAuthenticated)
            {
                // Store session data
                HttpContext.Session.SetString("BranchCode", response.Data.BranchCode ?? "");
                HttpContext.Session.SetString("BranchName", response.Data.BranchName ?? "");
                HttpContext.Session.SetString("DefaultServer", response.Data.DefaultServer ?? "");

                return RedirectToAction("Index", "Group");
            }

            ModelState.AddModelError("", "User หรือ Password ไม่ถูกต้อง");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "เกิดข้อผิดพลาดในการเชื่อมต่อ กรุณาลองใหม่อีกครั้ง" + ex.Message.ToString());
            // Log the exception
        }

        await PopulateBranches(model);
        return View(model);
    }
}
