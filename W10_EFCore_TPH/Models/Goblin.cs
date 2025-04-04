using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W10_EFCore_TPH.Models
{
    public class Goblin : Character
    {
        public int AggressionLevel { get; set; }
        public override string CharacterType { get; set; } = "Goblin";
    }
}
