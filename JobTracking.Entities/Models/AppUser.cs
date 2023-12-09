namespace JobTracking.Entities.Models;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;

    public List<AppJob>? AppJobs { get; set; }
}