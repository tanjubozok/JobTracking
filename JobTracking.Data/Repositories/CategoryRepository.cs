namespace JobTracking.Data.Repositories;

public class CategoryRepository(DatabaseContext context) 
    : GenericRepository<Category>(context), ICategoryRepository
{
}
