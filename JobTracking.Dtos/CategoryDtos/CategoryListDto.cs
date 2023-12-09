using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.CategoryDtos;

public class CategoryListDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}
