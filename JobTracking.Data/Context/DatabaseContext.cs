using JobTracking.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Data.Context;

public class DatabaseContext : IdentityDbContext<AppUser, AppRole, int>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<AppJob> AppJobs { get; set; }
    public DbSet<Category> Categories { get; set; }
}