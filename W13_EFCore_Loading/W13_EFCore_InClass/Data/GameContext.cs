using Microsoft.EntityFrameworkCore;
using W13_EFCore_InClass.Models;

namespace W13_EFCore_InClass.Data;

public class GameContext : DbContext
{
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("RpgDemo");
    }
}
