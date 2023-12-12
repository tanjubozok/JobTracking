namespace JobTracking.Data.Repositories;

public class AppNotificationRepository(DatabaseContext context)
        : GenericRepository<AppNotification>(context), IAppNotificationRepository
{
}
