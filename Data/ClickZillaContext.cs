using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class ClickZillaContext : DbContext
{
    public ClickZillaContext()
    {
    }

    public ClickZillaContext(DbContextOptions<ClickZillaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Enemy> Enemies { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ClickZilla;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enemy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enemy_pk");

            entity.ToTable("enemy");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Exp)
                .HasDefaultValue(0)
                .HasColumnName("exp");
            entity.Property(e => e.Hp).HasColumnName("hp");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Location).WithMany(p => p.Enemies)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("enemy_location_fk");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("location_pk");

            entity.ToTable("location");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Needexp)
                .HasDefaultValue(0)
                .HasColumnName("needexp");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EnemiesKilled).HasDefaultValue(0);
            entity.Property(e => e.UserExp).HasDefaultValue(0);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
