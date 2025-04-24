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
        public Item? Weapon { get; set; }
        public Item? Armor { get; set; }
    }
}
