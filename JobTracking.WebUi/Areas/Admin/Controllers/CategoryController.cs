namespace JobTracking.WebUi.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(ICategoryService categoryService, IToastNotification notify) : Controller
{
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IToastNotification _notify;

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var result = await _categoryService.GetCategoryListAsync();
        if (result.ResponseType == ResponseType.Success)
            return View(result.Data);
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CategoryAddDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryAddDto dto)
    {
        if (ModelState.IsValid)
        {
            var result = await _categoryService.CategoryAddAsync(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                _notify.AddSuccessToastMessage(result.Message);
                return RedirectToAction("List", "Category", new { area = "Admin" });
            }
            else
                _notify.AddAlertToastMessage(result.Message);
        }        
        return View(dto);
    }
}