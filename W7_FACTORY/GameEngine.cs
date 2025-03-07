using System.Runtime.InteropServices;
using W7_FACTORY.Data;
using W7_FACTORY.Models.Characters;
using W7_FACTORY.Models.Interfaces;
using W7_FACTORY.Models.Rooms;

namespace W7_FACTORY;

public class GameEngine
{
    private readonly ICharacter _character;
    private readonly ICharacter _ghost;
    private readonly ICharacter _goblin;

    public GameEngine(IDataContext context)
    {
        var goblins = context.Characters.OfType<Goblin>();
        var ghosts = context.Characters.OfType<Ghost>();
        var characters = context.Characters.OfType<Character>();

        _goblin = goblins.First();
        _ghost = ghosts.First();
        _character = characters.First();
    }

    public void Run()
    {
        var factory = new RoomFactory();
        var entrance = factory.CreateRoom("entrance");
        var jail = factory.CreateRoom("jail");
        var library = factory.CreateRoom("library");

        entrance.West = jail;
        entrance.East = library;

        jail.East = entrance;
        library.West = entrance;

        _character.EnterRoom(entrance);
    }

}


//_goblin.Move();
//_character.Move();
//_ghost.Move();

//_goblin.Attack();
      
//_character.Attack();

//_ghost.Attack();
//var g = (IFlyable)_ghost;
//g.Fly();