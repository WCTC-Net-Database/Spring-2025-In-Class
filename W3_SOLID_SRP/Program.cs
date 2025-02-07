using W3_SOLID_SRP.Models;
using W3_SOLID_SRP.Services;

namespace W3_SOLID_SRP
{

    // Displaying options for user
    // Reading from file
    // Writing to file
    // Parsing file into array

    public class Program
    {
        private Character x; // default? null
        private int y; // default? 0

        static void Main(string[] args)
        {
            CharacterManager manager = new CharacterManager();
            var characters = manager.Characters;

            var fighter = new Character("Bill");
            fighter.Class = "Fighter";
            fighter.Level = 1;
            fighter.HP = "10";
            fighter.Equipment = "Sword";

            Console.WriteLine("------------");
            manager.AddCharacter(fighter);
            foreach (Character c in characters)
            {
                Console.WriteLine(c);
            }

            manager.RemoveCharacter(fighter);
            Console.WriteLine("------------");
            foreach (Character c in characters)
            {
                Console.WriteLine(c);
            }

            // find a character
            var foundCharacter = manager.FindCharacterLINQ("Jermy");
           Console.WriteLine($"You found a character named {foundCharacter?.Name}");

            // remove the character
            manager.RemoveCharacter(foundCharacter);
            // display the characters
            Console.WriteLine("------------");
            foreach (Character c in characters)
            {
                Console.WriteLine(c);
            }
        }
    }
}