namespace JobTracking.Business.Services;

public interface ICategoryService
{
    Task<IResponse<List<CategoryListDto>>> CategoryListAsync();
    Task<IResponse<CategoryAddDto>> CategoryAddAsync(CategoryAddDto dto);
    Task<IResponse<CategoryUpdateDto>> CategoryUpdateAsync(CategoryUpdateDto dto);
    Task<IResponse<CategoryUpdateDto>> CategoryGetById(int categoryId);
}
