using W6_SOLID_DIP.Models;

namespace W6_SOLID_DIP.Data;

public class TestingContext : IDataContext
{
    //public string[] Read()
    //{
    //    return new[] { "Character", "Goblin", "Ghost" };
    //}
    public List<EntityBase> Characters { get; set; }
}
