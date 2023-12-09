namespace JobTracking.Data.Repositories;

public class AppJobRepository : GenericRepository<AppJob>, IAppJobRepository
{
    public AppJobRepository(DatabaseContext context)
        : base(context)
    {
    }
}
