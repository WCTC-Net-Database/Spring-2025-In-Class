using EFCoreInMemoryRPG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreInMemoryRPG.Data
{
    public class GameContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Player> Players => Set<Player>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Equipment> Equipment => Set<Equipment>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseInMemoryDatabase("RPGDemo")
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging(); // Optional but useful for seeing parameter values
        }
    }
}
