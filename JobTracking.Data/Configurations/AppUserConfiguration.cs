namespace JobTracking.Data.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers");

        builder.Property(x => x.Name)
            .HasMaxLength(64);

        builder.Property(x => x.Surname)
            .HasMaxLength(64);

        builder.HasMany(x => x.AppJobs)
            .WithOne(x => x.AppUser)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
