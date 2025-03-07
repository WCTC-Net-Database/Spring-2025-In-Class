using Microsoft.Extensions.DependencyInjection;
using W7_FACTORY.Data;

namespace W7_FACTORY;

public class Program
{
    private static void Main(string[] args)
    {
        // setup
        var serviceCollection = new ServiceCollection();
        
        // define the needed dependencies <- will add more as necessary
        //serviceCollection.AddTransient<CharacterManager>();
        serviceCollection.AddTransient<IDataContext, DataContext>();

        // build the collection
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Execute
        var context = serviceProvider.GetService<IDataContext>();
        var gameEngine = new GameEngine(context);
        gameEngine.Run();
    }
}
