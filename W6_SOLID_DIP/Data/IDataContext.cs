using W6_SOLID_DIP.Models;

namespace W6_SOLID_DIP.Data;

public interface IDataContext
{
    // READ
    List<EntityBase> Characters { get; set; }

    //string[] Read();
}