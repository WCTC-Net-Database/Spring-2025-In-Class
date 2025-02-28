using System.Text.Json;
using W6_SOLID_DIP.Models;

namespace W6_SOLID_DIP.Data;

public class JsonFileManager : IDataContext
{
    private string _filename = "Files/input.json";
    private string _json;

    public JsonFileManager()
    {
        _json = File.ReadAllText(_filename);
    }

    public string[] Read()
    {
        var characters = JsonSerializer.Deserialize<List<Character>>(_json);

        return characters.Select(c => c.Name).ToArray();
    }

    public List<EntityBase> Characters { get; set; }
}
