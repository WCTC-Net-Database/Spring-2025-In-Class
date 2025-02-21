using W5_SOLID_ISP_LSP.Data;
using W5_SOLID_ISP_LSP.Models;

namespace W5_SOLID_ISP_LSP;

public class Program
{
    private static void Main(string[] args)
    {
        IEntity goblin = new Goblin { Name = "Goblin" };
        IEntity character = new Character { Name = "Character" };
        IEntity ghost = new Ghost { Name = "Ghost" };

        var gameEngine = new GameEngine(character, goblin, ghost);
        gameEngine.Run();

    }














    // This will not work because the character class does not implement the IFlyable interface
    //character.Fly(); 


    //Console.WriteLine("Enter value 1");
    //var input1 = Console.ReadLine();
    //Console.WriteLine("Enter value 2");
    //var input2 = Console.ReadLine();


    //var was1Parsed = int.TryParse(input1, out int input1int);
    //var was2Parsed = int.TryParse(input2, out int input2int);

    //if (!was1Parsed)
    //{
    //    input1int = 0;
    //}
    //var result = input1int + input2int;

    //Console.WriteLine(result);

    public string MyTry(string x, out int result)
    {
        Console.WriteLine("{x}");

        result = 5;
        return x;

    }
}
