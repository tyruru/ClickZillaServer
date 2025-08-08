namespace ClickZillaServer.Models;

public class UpdateUserRequest
{
    public Guid UserId { get; set; }
    public int? UserExp { get; set; }
    public int? EnemiesKilled { get; set; }
}