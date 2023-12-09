namespace JobTracking.Data.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
        [
            new()
            {
                Id = 1,
                Name = "Acil",
                Color = "danger"
            },
            new()
            {
                Id = 2,
                Name = "Bu hafta",
                Color = "success"
            },
            new()
            {
                Id = 3,
                Name = "Bugün",
                Color = "info"
            },
            new()
            {
                Id = 4,
                Name = "Bu ay",
                Color = "warning"
            }
        ]);
    }
}
