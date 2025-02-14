using W4_SOLID_OCP.Models;
using W4_SOLID_OCP.Services;

namespace W4_SOLID_OCP.Data;

// manage the data (soon to be database?)
public class DataContext
{
    public List<Character> Characters { get; set; } = new();
    //public List<Monster> Monsters { get; set; }
    //public List<Room> Rooms { get; set; }
    //public List<Item> Items { get; set; }

    public string[] FileContents { get; set; }

    // default constructor
    public DataContext()
    {
        // csv
        //IFileManager fileManager = new CsvFileManager("Files/input.csv");
        //FileContents = fileManager.ReadFile();

        // json
        IFileManager fileManager = new JsonFileManager("Files/input.json");
        FileContents = fileManager.ReadFile();

        //var file = new CsvFileManager("Files/input.csv");
        //FileContents = file.ReadFile();

        PopulateCharactersFromFile();

    }


    public void AddCharacter(Character character)
    {
        Characters.Add(character);
    }

    public Character? FindCharacter(string name)
    {
        //var results = Characters.Where(c => CompareCharacterName(c));
        return Characters.Where(c => c.Name == name).FirstOrDefault();
    }

    public void RemoveCharacter(Character character)
    {
        Characters.Remove(character);
    }

    private void PopulateCharactersFromFile()
    {
        foreach (var name in FileContents)
        {
            Characters.Add(new Character { Name = name });
        }
    }
}
