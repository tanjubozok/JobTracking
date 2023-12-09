namespace JobTracking.Data.Seeds;

public class AppJobSeed : IEntityTypeConfiguration<AppJob>
{
    public void Configure(EntityTypeBuilder<AppJob> builder)
    {
        builder.HasData(
        [
            new()
            {
                Id=1,
                Name = "tanjubozok.com sitesindeki footer düzenlenecek",
                Description = "tanjubozok.com sitesinde kii footer yeni gelen telefon ve mail adresi ile değiştirmek gerekiyor",
                CategoryId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow.AddMinutes(30)
            },
            new()
            {
                Id=2,
                Name = "tanjubozok.com sitesindeki banner düzenlenecek",
                Description = "tanjubozok.com sitesinde ki banner yeni gelen logo ile değiştirmek gerekiyor",
                CategoryId = 2,
                IsActive = true,
                CreatedDate = DateTime.UtcNow.AddMinutes(120)
            },
            new()
            {
                Id=3,
                Name = "tanjubozok.com sitesindeki kategori düzenlenecek",
                Description = "tanjubozok.com sitesinde ki kategoriler a-z sıralanacak ve kaç adet iş olduğu belirtilecek",
                CategoryId = 3,
                IsActive = true,
                CreatedDate = DateTime.UtcNow.AddMinutes(240)
            }
        ]);
    }
}
