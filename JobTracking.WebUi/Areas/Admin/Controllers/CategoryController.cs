namespace JobTracking.WebUi.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(ICategoryService categoryService, IToastNotification notify) : Controller
{
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IToastNotification _notify = notify;

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var result = await _categoryService.CategoryListAsync();
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

    public async Task<IActionResult> Edit(int id)
    {
        var result = await _categoryService.CategoryGetById(id);
        if (result.ResponseType == ResponseType.Success)
            return View(result.Data);
        _notify.AddAlertToastMessage(result.Message);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryUpdateDto dto)
    {
        if (ModelState.IsValid)
        {
            var result = await _categoryService.CategoryUpdateAsync(dto);
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