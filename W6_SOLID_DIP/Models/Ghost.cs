namespace W6_SOLID_DIP.Models
{
    public class Ghost : EntityBase, IFlyable
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
