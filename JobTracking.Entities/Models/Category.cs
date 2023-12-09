namespace JobTracking.Entities.Models;

public class Category : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    public List<AppJob>? AppJobs { get; set; }
}