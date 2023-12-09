namespace JobTracking.Business.Services;

public interface ICategoryService
{
    Task<IGenericResponse<List<CategoryListDto>>> GetCategoryListAsync();

    Task<IGenericResponse<CategoryAddDto>> CategoryAddAsync(CategoryAddDto dto);
    Task<IGenericResponse<CategoryUpdateDto>> CategoryUpdateDto(CategoryUpdateDto dto);
}
