namespace JobTracking.Data.Context;

public class DatabaseContext : IdentityDbContext<AppUser, AppRole, int>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region configurations

        builder.ApplyConfiguration(new AppJobConfiguration());
        builder.ApplyConfiguration(new AppReportConfiguration());
        builder.ApplyConfiguration(new AppUserConfiguration());
        builder.ApplyConfiguration(new AppRoleConfiguration());
        builder.ApplyConfiguration(new AppNotificationConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());

        #endregion

        #region seeds

        builder.ApplyConfiguration(new AppJobSeed());
        builder.ApplyConfiguration(new AppReportSeed());
        builder.ApplyConfiguration(new CategorySeed());

        #endregion

        base.OnModelCreating(builder);
    }

    public DbSet<AppJob> AppJobs { get; set; }
    public DbSet<AppReport> AppReports { get; set; }
    public DbSet<AppNotification> AppNotifications { get; set; }
    public DbSet<Category> Categories { get; set; }
}