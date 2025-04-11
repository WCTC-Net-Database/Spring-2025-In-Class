using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using W11_EFCore_Refactor.Services;

namespace W11_EFCore_Refactor;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        // Hardcoded reference the database connection
        //var configuration = new ConfigurationBuilder()
        //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        //services.AddDbContext<GameContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        //);

        // Using the connection helper to connect to the database
        var configuration = ConfigurationHelper.GetConfiguration();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<GameContext>(options =>
        {
            ConfigurationHelper.ConfigureDbContextOptions(options, connectionString);
        });


        services.AddTransient<GameEngine>();

    }
}