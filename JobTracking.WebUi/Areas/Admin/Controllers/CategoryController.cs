namespace JobTracking.WebUi.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(ICategoryService categoryService) : Controller
{
    private readonly ICategoryService _categoryService = categoryService;

    public async Task<IActionResult> List()
    {
        var result = await _categoryService.GetCategoryListAsync();
        if (result.ResponseType == ResponseType.Success)
            return View(result.Data);
        return View();
    }
}