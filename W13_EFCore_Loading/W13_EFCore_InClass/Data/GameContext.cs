using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using W13_EFCore_InClass.Models;

namespace W13_EFCore_InClass.Data;

public class GameContext : DbContext
{
    public static ILoggerFactory MyLoggerFactory 
        = LoggerFactory.Create(b => b.AddConsole());

    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options //.UseInMemoryDatabase("RpgDemo")
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCoreRPGDemo;Trusted_Connection=True;")
            .UseLazyLoadingProxies()
            .UseLoggerFactory(MyLoggerFactory)
            .EnableSensitiveDataLogging();
    }
}
