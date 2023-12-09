namespace JobTracking.Data.Seeds;

public class AppReportSeed : IEntityTypeConfiguration<AppReport>
{
    public void Configure(EntityTypeBuilder<AppReport> builder)
    {
        builder.HasData(
        [
            new()
            {
                Id=1,
                CreatedDate = DateTime.UtcNow.AddDays(1),
                Name="Değişti",
                Description="Mail adresi değiştirildi",
                AppJobId=1,
            },
            new()
            {
                Id=2,
                CreatedDate = DateTime.UtcNow.AddDays(2),
                Name="Değişti-2",
                Description="Telefon adresi değiştirildi",
                AppJobId=1,
            },
            new()
            {
                Id=3,
                CreatedDate = DateTime.UtcNow.AddDays(3),
                Name="Değişti",
                Description="Belirtilen logo ile değiştirildi",
                AppJobId=2,
            }
        ]);
    }
}
