namespace JobTracking.Business.Manager;

public class CategoryManager(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<IResponse<CategoryAddDto>> CategoryAddAsync(CategoryAddDto dto)
    {
        try
        {
            var getCategory = _mapper.Map<Category>(dto);
            await _unitOfWork.CategoryRepository.AddAsync(getCategory);
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
                return new Response<CategoryAddDto>(ResponseType.Success, dto, $"{dto.Name} eklendi");
            else
                return new Response<CategoryAddDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
        }
        catch (Exception ex)
        {
            return new Response<CategoryAddDto>(ResponseType.TryCatch, ex.Message);
        }
    }

    public async Task<IResponse<CategoryUpdateDto>> CategoryUpdateDto(CategoryUpdateDto dto)
    {
        try
        {
            var mapCategory = _mapper.Map<Category>(dto);
            _unitOfWork.CategoryRepository.Update(mapCategory);
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
                return new Response<CategoryUpdateDto>(ResponseType.Success, dto, $"{dto.Name} güncellendi");
            else
                return new Response<CategoryUpdateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
        }
        catch (Exception ex)
        {
            return new Response<CategoryUpdateDto>(ResponseType.TryCatch, ex.Message);
        }
    }

    public async Task<IResponse<List<CategoryListDto>>> GetCategoryListAsync()
    {
        try
        {
            var categoryList = await _unitOfWork.CategoryRepository.GetAllAsync();
            var mapCategory = _mapper.Map<List<CategoryListDto>>(categoryList);
            if (mapCategory is not null)
                return new Response<List<CategoryListDto>>(ResponseType.Success, mapCategory);
            else
                return new Response<List<CategoryListDto>>(ResponseType.NotFound, "Kategori bulunamadı");
        }
        catch (Exception ex)
        {
            return new Response<List<CategoryListDto>>(ResponseType.TryCatch, ex.Message);
        }
    }
}
