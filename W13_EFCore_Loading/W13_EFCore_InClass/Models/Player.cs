using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W13_EFCore_InClass.Models
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
    }
}
