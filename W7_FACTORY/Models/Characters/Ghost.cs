using W7_FACTORY.Models.Interfaces;

namespace W7_FACTORY.Models.Characters
{
    public class Ghost : CharacterBase, IFlyable
    {
        public string Treasure { get; set; }

        public void Move()
        {
            Console.WriteLine($"{Name} moves");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies");
        }
    }
}
