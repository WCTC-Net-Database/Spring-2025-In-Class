using W2_EnhancedFileIO.Services;

namespace W2_EnhancedFileIO
{

    // Displaying options for user
    // Reading from file
    // Writing to file
    // Parsing file into array

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");

            var menuOption = Console.ReadLine();

            if (menuOption == "1")
            {
                CharacterManager.DisplayCharacters();
            }

            if (menuOption == "2")
            {
                CharacterManager.AddCharacter("Jane");
            }

            if (menuOption == "3")
            {

            }
        }


    }
}