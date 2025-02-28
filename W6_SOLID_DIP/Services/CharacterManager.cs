using W6_SOLID_DIP.Data;

namespace W6_SOLID_DIP.Services
{
    public class CharacterManager
    {
        private readonly IDataContext _context;

        public CharacterManager(IDataContext context)
        {
            _context = context;
        }

        //public void LoadData()
        //{
        //    //var context = new TestingContext();
        //    _context.Read();
        //}
    }
}
