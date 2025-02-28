using Microsoft.Extensions.DependencyInjection;
using W6_SOLID_DIP.Data;
using W6_SOLID_DIP.Models;
using W6_SOLID_DIP.Services;

namespace W6_SOLID_DIP;

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

        // moved to GameEngine
        //IEntity goblin = new Goblin { Name = "Goblin" };
        //IEntity character = new Character { Name = "Character" };
        //IEntity ghost = new Ghost { Name = "Ghost" };

        //var manager = new CharacterManager();
        //var mainProgram = new MainProgram();
    }
}
