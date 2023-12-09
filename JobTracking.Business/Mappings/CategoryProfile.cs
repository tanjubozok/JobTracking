namespace JobTracking.Business.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        this.CreateMap<Category, CategoryListDto>().ReverseMap();
        this.CreateMap<Category, CategoryAddDto>().ReverseMap();
        this.CreateMap<Category, CategoryUpdateDto>().ReverseMap();
    }
}
