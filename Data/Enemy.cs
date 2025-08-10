namespace Data;

public partial class Enemy : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Hp { get; set; }

    public int Exp { get; set; }

    public Guid? LocationId { get; set; }

    public virtual Location? Location { get; set; }
}
