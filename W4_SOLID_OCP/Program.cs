using W4_SOLID_OCP.Data;

namespace W4_SOLID_OCP;

public class Program
{
    private static void Main(string[] args)
    {
        var context = new DataContext();
        var characters = context.Characters;

        foreach (var c in characters)
        {
            Console.WriteLine(c);
        }
    }
}
