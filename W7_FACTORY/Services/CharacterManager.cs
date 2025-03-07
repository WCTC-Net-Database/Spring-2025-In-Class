using W7_FACTORY.Data;

namespace W7_FACTORY.Services
{
    public class CharacterManager
    {
        private readonly IDataContext _context;

        public CharacterManager(IDataContext context)
        {
            _context = context;
        }
    }
}
