using Microsoft.Extensions.DependencyInjection;
using W11_EFCore_Refactor.Services;

namespace W11_EFCore_Refactor;

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