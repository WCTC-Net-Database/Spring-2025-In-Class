using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpgEntities.Models
{
    // TPH??
    // Should the Player have a List<Item> ??
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class Weapon : Item
    {
        public int AttackRating { get; set; }
    }

    public class Shield : Item
    {
        public int DefenseRating { get; set; }
    }
}
