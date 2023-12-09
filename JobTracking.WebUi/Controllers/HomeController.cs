using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUi.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
