namespace W6_SOLID_DIP.Models
{
    public class Goblin : EntityBase, ILootable
    {
        public string Treasure { get; set; }

        public override void Move()
        {
            Console.WriteLine($"{Name} stomps");
        }
    }
}
