using W7_FACTORY.Models.Characters;

namespace W7_FACTORY.Data;

public interface IDataContext
{
    // READ
    List<CharacterBase> Characters { get; set; }

    //string[] Read();
}