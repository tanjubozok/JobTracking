using JobTracking.Business.Services;
using JobTracking.Common.ComplexTypes;

namespace JobTracking.WebUi.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> List()
    {
        var result = await _categoryService.GetCategoryListAsync();
        if (result.ResponseType == ResponseType.Success)
            return View(result.Data);
        return View();
    }
}
