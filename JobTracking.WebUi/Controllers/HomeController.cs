namespace JobTracking.WebUi.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("List", "Category", new { area = "Admin" });
    }
}
