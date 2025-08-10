namespace ClickZillaServer.Models;

public class MobKilledModel
{
    public int? Exp { get; set; }
    public int? EnemiesKilled { get; set; }
    public string CurrentEnemyName { get; set; }
    public bool IsNewLocateUnlocked { get; set; }
}