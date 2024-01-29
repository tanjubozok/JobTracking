namespace JobTracking.Business.Services;

public interface ICategoryService
{
    Task<IResponse<List<CategoryListDto>>> GetCategoryListAsync();
    Task<IResponse<CategoryAddDto>> CategoryAddAsync(CategoryAddDto dto);
    Task<IResponse<CategoryUpdateDto>> CategoryUpdateDto(CategoryUpdateDto dto);
}
