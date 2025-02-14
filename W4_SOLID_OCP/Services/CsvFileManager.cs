using W4_SOLID_OCP.Models;

namespace W4_SOLID_OCP.Services;

// CRUD operations for CSV files
// Create, Read, Update, Delete
public class CsvFileManager : IFileManager
{
    public string FileName { get; set; }

    public CsvFileManager(string fileName)
    {
        FileName = fileName;
    }

    public string[] ReadFile()
    {
        return File.ReadAllLines(FileName);
    }

    public void WriteFile(List<Character> characters)
    {
        Console.WriteLine("Writing");
    }
}
