namespace JobTracking.Data.Configurations;

public class AppJobConfiguration : IEntityTypeConfiguration<AppJob>
{
    public void Configure(EntityTypeBuilder<AppJob> builder)
    {
        builder.ToTable("AppJobs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(x => x.Description)
            .HasMaxLength(2048);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasMany(x => x.AppReports)
            .WithOne(x => x.AppJob)
            .HasForeignKey(x => x.AppJobId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}