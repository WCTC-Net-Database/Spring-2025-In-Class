namespace W11_EFCore_Refactor.Services
{

    // Have the CRUD operations
    public interface IRepository
    {
        void Add();
        void Get();
        void Update();
        void Delete();
    }
    public class PlayerRepository : IRepository
    {
        void GetPlayerByName(string name)
        {
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }

    // encapsulate all the business logic
    public class PlayerService
    {
        public IRepository _repo;
        public PlayerService(PlayerRepository repo)
        {
            _repo = repo;
        }

        public void GetPlayerByName(string name)
        {
            _repo.Get();
        }
    }

    public class GameEngine
    {

        public PlayerService _service;
        public GameEngine(PlayerService service)
        {
            _service = service;
        }
        public void Run()
        {
            _service.GetPlayerByName("Sir Lancelot");

            //var player = _context.Players.First(c => c.Name == "Sir Lancelot");
            //var goblin = _context.Monsters.First(c => c.Name == "Bob Goblin");

            //player.Attack(goblin);

            //var ability = player.Abilities.First();
            //player.UseAbility(ability, goblin);

            //goblin.Attack(player);

        }
    }
}

// UNIT OF WORK
