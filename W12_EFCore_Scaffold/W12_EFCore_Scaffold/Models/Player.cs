using System;
using System.Collections.Generic;

namespace W12_EFCore_Scaffold.Models;

public partial class Player
{
    public int Id { get; set; }

    public int Experience { get; set; }

    public string Name { get; set; } = null!;

    public int Health { get; set; }

    public int? EquipmentId { get; set; }

    public virtual Equipment? Equipment { get; set; }

    public virtual ICollection<Ability> Abilities { get; set; } = new List<Ability>();
}



