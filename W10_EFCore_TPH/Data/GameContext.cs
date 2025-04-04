using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using W10_EFCore_TPH.Models;

namespace W10_EFCore_TPH.Data
{
    public class GameContext : DbContext
    {
        // makes sense to use TPH if low column count in the concrete classes
        public DbSet<Character> Characters { get; set; }

        // Use the concrete directly if the concretes have a high number of columns
        //public DbSet<Player> Players { get; set; }
        //public DbSet<Goblin> Goblins { get; set; }


        // default constructor - design time
        public GameContext() 
        {

        }

        // constructor used at run time
        public GameContext(DbContextOptions<GameContext> options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json");
            var config = configuration.Build();

            // build the configuration object

            // Shorthand for GetSection("ConnectionStrings")[name].
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPH (Table Per Hierarchy) configuration
            modelBuilder.Entity<Character>()
                .HasDiscriminator(c=>c.CharacterType)
                .HasValue<Player>(nameof(Player))
                .HasValue<Goblin>(nameof(Goblin));

            base.OnModelCreating(modelBuilder);
        }
    }
}
