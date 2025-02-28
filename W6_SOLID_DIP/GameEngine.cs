using System.Security.Cryptography.X509Certificates;
using W6_SOLID_DIP.Data;
using W6_SOLID_DIP.Models;
using W6_SOLID_DIP.Services;

namespace W6_SOLID_DIP;

public class GameEngine
{
    private readonly IEntity _character;
    private readonly IEntity _ghost;
    private readonly IEntity _goblin;

    public GameEngine(IDataContext context)
    {
        //var manager = new CharacterManager();
        //var goblins = context.Characters.Where(x=>x is Goblin);
        var goblins = context.Characters.OfType<Goblin>();
        var ghosts = context.Characters.OfType<Ghost>();
        var characters = context.Characters.OfType<Character>();

        _goblin = goblins.First();
        _ghost = ghosts.First();
        _character = characters.First();
    }

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

        //if (_goblin is ILootable)
        //{
        //    _character.Inventory.Add(_goblin.Treasure);
        //}
    }
}
