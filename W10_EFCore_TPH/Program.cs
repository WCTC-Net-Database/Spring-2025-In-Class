using Microsoft.Extensions.DependencyInjection;
using W10_EFCore_TPH.Services;

namespace W10_EFCore_TPH;

public static class Program
{
    public static void Main()
    {
        var serviceCollection = new ServiceCollection();
        Startup.ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var gameEngine = serviceProvider.GetService<GameEngine>();
        gameEngine?.Run();
    }
}