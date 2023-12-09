namespace JobTracking.Business.Manager;

public class CategoryManager : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IGenericResponse<CategoryAddDto>> CategoryAddAsync(CategoryAddDto dto)
    {
        try
        {
            var getCategory = _mapper.Map<Category>(dto);
            await _unitOfWork.CategoryRepository.AddAsync(getCategory);
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
                return new GenericResponse<CategoryAddDto>(ResponseType.Success, dto, $"{dto.Name} eklendi");
            else
                return new GenericResponse<CategoryAddDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
        }
        catch (Exception ex)
        {
            return new GenericResponse<CategoryAddDto>(ResponseType.TryCatch, ex.Message);
        }
    }

    public async Task<IGenericResponse<CategoryUpdateDto>> CategoryUpdateDto(CategoryUpdateDto dto)
    {
        try
        {
            var mapCategory = _mapper.Map<Category>(dto);
            _unitOfWork.CategoryRepository.Update(mapCategory);
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
                return new GenericResponse<CategoryUpdateDto>(ResponseType.Success, dto, $"{dto.Name} güncellendi");
            else
                return new GenericResponse<CategoryUpdateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
        }
        catch (Exception ex)
        {
            return new GenericResponse<CategoryUpdateDto>(ResponseType.TryCatch, ex.Message);
        }
    }

    public async Task<IGenericResponse<List<CategoryListDto>>> GetCategoryListAsync()
    {
        try
        {
            var categoryList = await _unitOfWork.CategoryRepository.GetAllAsync();
            var mapCategory = _mapper.Map<List<CategoryListDto>>(categoryList);
            if (mapCategory is not null)
                return new GenericResponse<List<CategoryListDto>>(ResponseType.Success, mapCategory);
            else
                return new GenericResponse<List<CategoryListDto>>(ResponseType.NotFound, "Kategori bulunamadı");
        }
        catch (Exception ex)
        {
            return new GenericResponse<List<CategoryListDto>>(ResponseType.TryCatch, ex.Message);
        }
    }
}
