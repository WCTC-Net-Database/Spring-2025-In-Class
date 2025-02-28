namespace W6_SOLID_DIP.Models
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }

        public virtual void Move()
        {
            Console.WriteLine($"{Name} moves");
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name} attacks");
        }
    }
}
