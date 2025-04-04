namespace W10_EFCore_TPH.Models
{
    public abstract class Character : ICharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public abstract string CharacterType { get; set; }

        public virtual void Attack(ICharacter target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}!");
        }

    }
}
