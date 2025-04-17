using System;
using System.Collections.Generic;

namespace W12_EFCore_Scaffold.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Weapon { get; set; } = null!;

    public string Armor { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
