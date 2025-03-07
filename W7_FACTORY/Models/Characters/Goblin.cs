using W7_FACTORY.Models.Interfaces;

namespace W7_FACTORY.Models.Characters
{
    public class Goblin : CharacterBase, ILootable
    {
        public string Treasure { get; set; }

        public override void Move()
        {
            Console.WriteLine($"{Name} stomps");
        }
    }
}
