namespace EFCoreInMemoryRPG.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Item? Weapon { get; set; }
        public Item? Armor { get; set; } 
    }
}
