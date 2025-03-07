using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W7_FACTORY.Models.Rooms
{
    public class RoomFactory
    {
        public IRoom CreateRoom(string roomType)
        {
            switch (roomType)
            {
                case "entrance":
                    return new Room("Entrance", "The entrance to the dungeon");
                case "treasure":
                    return new Room("Treasure", "A room full of treasure");
                case "jail":
                    return new Room("Jail", "A room full of prisoners");
                case "dungeon":
                    return new Room("Dungeon", "A dark and scary dungeon");
                case "library":
                    return new Room("Library", "A room full of books");
                case "trap":
                    return new TrappedRoom("Trapped!", "A room with a trap");
                default:
                    return new Room("Empty Room", "An empty room");
            }
        }
    }
}
