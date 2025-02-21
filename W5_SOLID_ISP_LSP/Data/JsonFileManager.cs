using System.Text.Json;
using W5_SOLID_ISP_LSP.Models;

namespace W5_SOLID_ISP_LSP.Data;

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
}
