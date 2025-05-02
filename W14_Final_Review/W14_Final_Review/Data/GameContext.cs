using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using W14_Final_Review.Models;

namespace W14_Final_Review.Data;

public class GameContext : DbContext
{
    //public static ILoggerFactory MyLoggerFactory 
    //    = LoggerFactory.Create(b => b.AddConsole());

    public static ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
        builder.ClearProviders();
        builder.AddFile("efcore-log.txt");  // Using Serilog.Extensions.Logging.File
    });

    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Ability> Abilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options //.UseInMemoryDatabase("RpgDemo")
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCoreRPGDemo;Trusted_Connection=True;")
            .UseLazyLoadingProxies()
            .UseLoggerFactory(MyLoggerFactory)
            .EnableSensitiveDataLogging();
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Configure self-referencing relationships for Room cardinal directions
    //    modelBuilder.Entity<Room>()
    //        .HasOne(r => r.NorthRoom)
    //        .WithMany()
    //        .HasForeignKey(r => r.NorthRoomId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<Room>()
    //        .HasOne(r => r.SouthRoom)
    //        .WithMany()
    //        .HasForeignKey(r => r.SouthRoomId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<Room>()
    //        .HasOne(r => r.EastRoom)
    //        .WithMany()
    //        .HasForeignKey(r => r.EastRoomId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<Room>()
    //        .HasOne(r => r.WestRoom)
    //        .WithMany()
    //        .HasForeignKey(r => r.WestRoomId)
    //        .OnDelete(DeleteBehavior.Restrict);
    //}
}
