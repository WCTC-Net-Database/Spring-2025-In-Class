namespace W5_SOLID_ISP_LSP.Data;

public class HardcodedContext : IDataContext
{
    public string[] Read()
    {
        return new[] { "Character", "Goblin", "Ghost" };
    }
}
