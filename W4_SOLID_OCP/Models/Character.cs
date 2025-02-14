namespace W4_SOLID_OCP.Models;

public class Character
{
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Character: {Name}";
    }
}
