namespace JobTracking.Data.Repositories;

public class AppNotificationRepository
    : GenericRepository<AppNotification>, IAppNotificationRepository
{
    public AppNotificationRepository(DatabaseContext context)
        : base(context)
    {
    }
}
