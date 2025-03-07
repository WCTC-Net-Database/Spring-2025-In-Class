using W7_FACTORY.Models.Interfaces;
using W7_FACTORY.Models.Rooms;

namespace W7_FACTORY.Models.Characters
{
    public abstract class CharacterBase : ICharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }

        public Room CurrentRoom { get; set; }

        public virtual void Move()
        {
            Console.WriteLine($"{Name} moves");
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name} attacks");
        }

        public void EnterRoom(IRoom room)
        {
            if (room != null)
            {
                CurrentRoom = (Room)room;
                Console.WriteLine($"{Name} enters {CurrentRoom.Name}");
                Console.WriteLine(CurrentRoom.Description);

                CurrentRoom.OnEnterRoom(this);
            }
            else
            {
                Console.WriteLine("You cannot go that way");
            }
        }
    }
}
