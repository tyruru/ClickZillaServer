using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClickZillaServer.Models;

public partial class ClickZillaContext : DbContext
{
    public ClickZillaContext()
    {
    }

    public ClickZillaContext(DbContextOptions<ClickZillaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ClickZilla;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
