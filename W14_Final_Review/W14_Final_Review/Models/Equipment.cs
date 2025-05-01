// Equipment.cs

namespace W14_EFCore_Linq.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        // this is your FK to Player
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; } = null!;

        // your existing item navs
        public virtual Item? Weapon { get; set; }
        public virtual Item? Armor { get; set; }
    }
}
