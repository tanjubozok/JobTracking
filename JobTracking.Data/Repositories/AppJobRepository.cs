namespace JobTracking.Data.Repositories;

public class AppJobRepository(DatabaseContext context)
    : GenericRepository<AppJob>(context), IAppJobRepository
{
}
