using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Mock login check
        if (username == "admin" && password == "1234")
        {
            // Save to session
            HttpContext.Session.SetString("user", username);
            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Error = "Invalid credentials";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
