using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5_SOLID_ISP_LSP.Data;
using W5_SOLID_ISP_LSP.Models;
using W5_SOLID_ISP_LSP.Services;

namespace W5_SOLID_ISP_LSP
{
    public class GameEngine
    {
        private readonly IEntity _character;
        private readonly IEntity _goblin;
        private readonly IEntity _ghost;

        public GameEngine(IEntity character, IEntity goblin, IEntity ghost)
        {
            // execute on instantiation
            _character = character;
            _goblin = goblin;
            _ghost = ghost;

            var manager = new CharacterManager();
            manager.LoadData();
        }

        //private void LoadData()
        //{
        //    // should GameEngine be responsible for loading data?
        //    // should GameEngine know where the data is coming from?
        //    var context = new JsonFileManager("Files/input.json");
        //}

        public void Run()
        {
            _goblin.Move();
            _character.Move();
            _ghost.Move();

            _goblin.Attack();
            _character.Attack();

            _ghost.Attack();
            var g = (IFlyable)_ghost;
            g.Fly();

            // alternate method to cast
            if (_ghost is IFlyable)
            {
                ((IFlyable)_ghost).Fly();
            }

        }
    }
}
