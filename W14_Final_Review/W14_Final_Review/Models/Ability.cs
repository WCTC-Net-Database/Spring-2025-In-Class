namespace W14_Final_Review.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }

        // Foreign key linking to a Player
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; } = null!;
    }
}
