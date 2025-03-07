using W7_FACTORY.Models.Rooms;

namespace W7_FACTORY.Models.Interfaces
{
    public interface ICharacter
    {
        void Move();
        void Attack();
        void EnterRoom(IRoom room);
    }
}
