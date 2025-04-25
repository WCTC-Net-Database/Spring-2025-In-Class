using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W13_EFCore_InClass.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }

        // navigation properties - must be virtual for Lazy Loading
        public virtual Item? Weapon { get; set; }
        public virtual Item? Armor { get; set; }
    }
}
