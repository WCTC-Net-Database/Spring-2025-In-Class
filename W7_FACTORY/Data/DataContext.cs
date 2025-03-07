using System.Text.Json;
using W7_FACTORY.Models.Characters;

namespace W7_FACTORY.Data;

public class DataContext : IDataContext
{
    public List<CharacterBase> Characters { get; set; }

    private readonly JsonSerializerOptions options;

    public DataContext()
    {
        options = new JsonSerializerOptions
        {
            Converters = { new CharacterBaseConverter() },
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        LoadData();
    }

    private void LoadData()
    {
        var jsonData = File.ReadAllText("Files/input.json");
        Characters = JsonSerializer.Deserialize<List<CharacterBase>>(jsonData, options); // Load all character types
    }
}
