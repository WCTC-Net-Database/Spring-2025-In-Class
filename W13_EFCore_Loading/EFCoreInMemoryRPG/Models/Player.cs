namespace EFCoreInMemoryRPG.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; } 
        public int Gold { get; set; } 
        public Equipment? Equipment { get; set; }
        public List<Item> Inventory { get; set; } = new();
    }
}
