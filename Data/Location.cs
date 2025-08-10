namespace Data;

public partial class Location : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Needexp { get; set; }

    public virtual ICollection<Enemy> Enemies { get; set; } = new List<Enemy>();
}
