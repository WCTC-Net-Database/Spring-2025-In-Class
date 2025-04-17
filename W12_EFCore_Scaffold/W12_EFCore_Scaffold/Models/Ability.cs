using System;
using System.Collections.Generic;

namespace W12_EFCore_Scaffold.Models;

public partial class Ability
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string AbilityType { get; set; } = null!;

    public int? Damage { get; set; }

    public int? Distance { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
