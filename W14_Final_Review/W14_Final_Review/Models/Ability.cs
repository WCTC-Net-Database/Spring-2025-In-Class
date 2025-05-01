using System.ComponentModel.DataAnnotations.Schema;

namespace W14_EFCore_Linq.Models
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
