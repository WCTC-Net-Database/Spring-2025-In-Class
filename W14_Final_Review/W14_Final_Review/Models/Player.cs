namespace W14_EFCore_Linq.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public int Gold { get; set; }

        // navigation properties - must be virtual for Lazy Loading
        public virtual Equipment? Equipment { get; set; }
        public virtual List<Item> Inventory { get; set; } = new();

        // New Room properties
        public int? RoomId { get; set; }
        public virtual Room? Room { get; set; }
    }
}
