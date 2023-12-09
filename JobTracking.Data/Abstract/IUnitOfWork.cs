namespace JobTracking.Data.Abstract;

public interface IUnitOfWork : IDisposable
{
    IAppJobRepository AppJobRepository { get; }
    IAppNotificationRepository AppNotificationRepository { get; }
    IAppReportRepository AppReportRepository { get; }
    ICategoryRepository CategoryRepository { get; }

    Task<int> CommitAsync();
}
