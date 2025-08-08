using Data;

namespace ClickZillaServer.Models;

public partial class User : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? UserExp { get; set; }

    public int? EnemiesKilled { get; set; }
}
