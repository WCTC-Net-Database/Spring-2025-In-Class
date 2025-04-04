namespace W10_EFCore_TPH.Models;

public class Player : Character
{
    public int Experience { get; set; }
    public override string CharacterType { get; set; } = "Player";
}
