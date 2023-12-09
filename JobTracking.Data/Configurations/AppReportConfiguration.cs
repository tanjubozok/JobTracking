namespace JobTracking.Data.Configurations;

public class AppReportConfiguration : IEntityTypeConfiguration<AppReport>
{
    public void Configure(EntityTypeBuilder<AppReport> builder)
    {
        builder.ToTable("AppReports");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(x => x.CreatedDate)
            .IsRequired();
    }
}
