namespace JobTracking.Business.Mappings;

public class ProfileHelper
{
    public static List<Profile> GetProfiles()
    {
        return
        [
            new CategoryProfile(),
        ];
    }
}
