using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace W12_EFCore_Scaffold.Models;

public partial class GameDatabaseContext : DbContext
{
    public GameDatabaseContext()
    {
    }

    public GameDatabaseContext(DbContextOptions<GameDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Monster> Monsters { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameDatabase;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ability>(entity =>
        {
            entity.HasMany(d => d.Players).WithMany(p => p.Abilities)
                .UsingEntity<Dictionary<string, object>>(
                    "PlayerAbility",
                    r => r.HasOne<Player>().WithMany().HasForeignKey("PlayersId"),
                    l => l.HasOne<Ability>().WithMany().HasForeignKey("AbilitiesId"),
                    j =>
                    {
                        j.HasKey("AbilitiesId", "PlayersId");
                        j.ToTable("PlayerAbilities");
                        j.HasIndex(new[] { "PlayersId" }, "IX_PlayerAbilities_PlayersId");
                    });
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasIndex(e => e.EquipmentId, "IX_Players_EquipmentId");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Players).HasForeignKey(d => d.EquipmentId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
