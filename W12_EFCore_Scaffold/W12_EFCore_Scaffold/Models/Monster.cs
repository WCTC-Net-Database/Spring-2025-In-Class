using System;
using System.Collections.Generic;

namespace W12_EFCore_Scaffold.Models;

public partial class Monster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Health { get; set; }

    public int AggressionLevel { get; set; }

    public string MonsterType { get; set; } = null!;

    public int? Sneakiness { get; set; }
}
