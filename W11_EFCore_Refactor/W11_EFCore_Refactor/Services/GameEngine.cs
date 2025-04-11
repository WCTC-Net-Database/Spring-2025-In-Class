using ConsoleRpgEntities.Data;

namespace W11_EFCore_Refactor.Services
{
    public class GameEngine
    {
        private readonly GameContext _context;

        public GameEngine(GameContext context)
        {
            _context = context;

        }
        public void Run()
        {
            var player = _context.Players.First(c => c.Name == "Sir Lancelot");
            var goblin = _context.Monsters.First(c => c.Name == "Bob Goblin");

            player.Attack(goblin);

            var ability = player.Abilities.First();
            player.UseAbility(ability, goblin);

            goblin.Attack(player);

        }
    }
}
