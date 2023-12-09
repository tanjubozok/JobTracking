namespace JobTracking.Data.Repositories;

public class AppReportRepository
    : GenericRepository<AppReport>, IAppReportRepository
{
    public AppReportRepository(DatabaseContext context)
        : base(context)
    {
    }
}
