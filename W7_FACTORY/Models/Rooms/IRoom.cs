namespace W7_FACTORY.Models.Rooms;

public interface IRoom
{
    string Name { get; set; }
    string Description { get; set; }
    public IRoom? West { get; set; }
    public IRoom? East { get; set; }
    public IRoom? North { get; set; }
    public IRoom? South { get; set; }

}
