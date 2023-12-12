namespace JobTracking.Data.UnitOfWorks;

public class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    private readonly DatabaseContext _context = context;
    private AppJobRepository _appJobRepository;
    private AppNotificationRepository _appNotification;
    private AppReportRepository _appReport;
    private CategoryRepository _category;

    public IAppJobRepository AppJobRepository
        => _appJobRepository ?? new AppJobRepository(_context);

    public IAppNotificationRepository AppNotificationRepository
        => _appNotification ?? new AppNotificationRepository(_context);

    public IAppReportRepository AppReportRepository
        => _appReport ?? new AppReportRepository(_context);

    public ICategoryRepository CategoryRepository
        => _category ?? new CategoryRepository(_context);

    public void Dispose()
        => _context.Dispose();

    public async Task<int> CommitAsync()
        => await _context.SaveChangesAsync();
}
