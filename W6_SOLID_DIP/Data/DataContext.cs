using System.Text.Json;
using W6_SOLID_DIP.Models;

namespace W6_SOLID_DIP.Data;

public class DataContext : IDataContext
{
    public List<EntityBase> Characters { get; set; }

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
        Characters = JsonSerializer.Deserialize<List<EntityBase>>(jsonData, options); // Load all character types
    }
}
