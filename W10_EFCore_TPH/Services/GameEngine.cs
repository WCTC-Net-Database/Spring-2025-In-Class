using W10_EFCore_TPH.Data;

namespace W10_EFCore_TPH.Services
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
            var player = _context.Characters.First(c => c.Name == "Sir John");
            var goblin = _context.Characters.First(c => c.Name == "Gob Boblin");

            player.Attack(goblin);
        }
    }
}
