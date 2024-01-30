namespace JobTracking.Business.Manager;

public class CategoryManager(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IResponse<CategoryAddDto>> CategoryAddAsync(CategoryAddDto dto)
    {
        try
        {
            var category = _mapper.Map<Category>(dto);

            if (await _unitOfWork.CategoryRepository.AnyAsync(x => x.Name.ToLower() == category.Name.ToLower()))
                return new Response<CategoryAddDto>(ResponseType.SameRecord, "Aynı kayıt veritabanında mevcuttur");

            await _unitOfWork.CategoryRepository.AddAsync(category);

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

    public async Task<IResponse<CategoryUpdateDto>> CategoryUpdateAsync(CategoryUpdateDto dto)
    {
        try
        {
            var category = _mapper.Map<Category>(dto);

            if (await _unitOfWork.CategoryRepository.AnyAsync(x => x.Name.ToLower() == category.Name.ToLower()))
                return new Response<CategoryUpdateDto>(ResponseType.SameRecord, "Aynı kayıt veritabanında mevcuttur");

            _unitOfWork.CategoryRepository.Update(category);

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

    public async Task<IResponse<CategoryUpdateDto>> CategoryGetById(int categoryId)
    {
        try
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == categoryId);

            var result = _mapper.Map<CategoryUpdateDto>(category);
            if (result is not null)
                return new Response<CategoryUpdateDto>(ResponseType.Success, result);
            else
                return new Response<CategoryUpdateDto>(ResponseType.NotFound, "Kategori bulunamadı");
        }
        catch (Exception ex)
        {
            return new Response<CategoryUpdateDto>(ResponseType.TryCatch, ex.Message);
        }
    }

    public async Task<IResponse<List<CategoryListDto>>> CategoryListAsync()
    {
        try
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync(null, x => x.Id);

            var result = _mapper.Map<List<CategoryListDto>>(categories);
            if (result is not null)
                return new Response<List<CategoryListDto>>(ResponseType.Success, result);
            else
                return new Response<List<CategoryListDto>>(ResponseType.NotFound, "Kategori bulunamadı");
        }
        catch (Exception ex)
        {
            return new Response<List<CategoryListDto>>(ResponseType.TryCatch, ex.Message);
        }
    }
}
