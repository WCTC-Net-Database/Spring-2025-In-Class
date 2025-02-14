using System.Text.Json;
using W4_SOLID_OCP.Models;

namespace W4_SOLID_OCP.Services;

public class JsonFileManager : IFileManager
{
    private string _json;

    public JsonFileManager(string fileName)
    {
        _json = File.ReadAllText(fileName);
    }

    public string[] ReadFile()
    {
        var characters = JsonSerializer.Deserialize<List<Character>>(_json);

        return characters.Select(c => c.Name).ToArray();
    }

    public void WriteFile(List<Character> characters)
    {
        _json = JsonSerializer.Serialize(characters);
    }
}
