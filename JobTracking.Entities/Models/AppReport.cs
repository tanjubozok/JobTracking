namespace JobTracking.Entities.Models;

public class AppReport : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int? AppJobId { get; set; }
    public AppJob? AppJob { get; set; }
}