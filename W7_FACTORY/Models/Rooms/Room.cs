using W7_FACTORY.Models.Characters;
using W7_FACTORY.Models.Interfaces;

namespace W7_FACTORY.Models.Rooms
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ICharacter> Characters { get; set; } = new List<ICharacter>();

        public IRoom? North { get; set; }
        public IRoom? South { get; set; }
        public IRoom? East { get; set; }
        public IRoom? West { get; set; }


        public Room(string name, string description)
        {
            Name = name;
            Description = description;

            Characters.Add(new Character { Name = "Timmy" });

        }

        public void OnEnterRoom(CharacterBase character)
        {
            if (North != null)
                Console.WriteLine($"There is an exit to the North: {North?.Description}");
            if (South != null)
                Console.WriteLine($"There is an exit to the South: {South?.Description}");
            if (East != null)
                Console.WriteLine($"There is an exit to the East: {East?.Description}");
            if (West != null)
                Console.WriteLine($"There is an exit to the West: {West?.Description}");

            Characters.Add(character);

            Console.WriteLine($"There are {Characters.Count} characters in the room");
            Console.WriteLine("Here you see:");
            foreach (var c in Characters)
            {
                Console.WriteLine(((CharacterBase)c).Name);
            }
        }
    }
}
