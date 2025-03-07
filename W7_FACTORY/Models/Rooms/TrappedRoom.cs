using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W7_FACTORY.Models.Rooms
{
    public class TrappedRoom : IRoom, ITrappable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IRoom? West { get; set; }
        public IRoom? East { get; set; }
        public IRoom? North { get; set; }
        public IRoom? South { get; set; }

        // default constructor
        public TrappedRoom(string name, string description) 
        {
                
        }

        public void Enter()
        {
        }

        public void Trap()
        {
        }
    }

    public interface ITrappable
    {
        void Trap();
    }
}
