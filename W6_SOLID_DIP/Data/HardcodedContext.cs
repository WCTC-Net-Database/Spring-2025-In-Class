using W6_SOLID_DIP.Models;

namespace W6_SOLID_DIP.Data;

public class HardcodedContext : IDataContext
{
    //public string[] Read()
    //{
    //    return new[] { "Bob", "Tom", "Larry" };
    //}

    public List<EntityBase> Characters { get; set; }
}

// Future EntityFramework Database Context
//public class DatabaseContext : DbContext
//{
//    public DbSet<Character> Characters { get; set; }  // database table
//}