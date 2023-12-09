namespace JobTracking.Entities.Models;

public class AppJob : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public int? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public List<AppReport>? AppReports { get; set; }
}