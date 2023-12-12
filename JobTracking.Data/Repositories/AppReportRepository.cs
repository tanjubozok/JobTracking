namespace JobTracking.Data.Repositories;

public class AppReportRepository(DatabaseContext context)
    : GenericRepository<AppReport>(context), IAppReportRepository
{
}
