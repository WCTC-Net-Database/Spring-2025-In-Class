using System.Collections;

namespace W3_SOLID_SRP.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public string HP { get; set; }
        public string Equipment { get; set; }

        public Character(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Class} {Level} {HP} {Equipment}";
        }

        public void LevelUpCharacter()
        {
           Level++;
        }

        public void DisplayCharacter()
        {
            // Display character
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"Equipment: {Equipment}");
        }
    }
}
