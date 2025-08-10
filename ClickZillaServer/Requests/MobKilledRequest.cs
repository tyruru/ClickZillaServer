namespace ClickZillaServer.Models;

public class MobKilledRequest
{
    public Guid UserId { get; set; }
    public string EnemyName { get; set; }
}