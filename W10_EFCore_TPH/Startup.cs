using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using W10_EFCore_TPH.Data;
using W10_EFCore_TPH.Services;

namespace W10_EFCore_TPH;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        services.AddDbContext<GameContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        // Entity Framework Factory for creating instance of DbContext
        //var contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<GameContext>>();
        //var context = contextFactory.CreateDbContext();

        services.AddTransient<GameEngine>();

    }
}