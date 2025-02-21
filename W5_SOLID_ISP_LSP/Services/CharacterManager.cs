using W5_SOLID_ISP_LSP.Data;

namespace W5_SOLID_ISP_LSP.Services
{
    public class CharacterManager
    {
        public void LoadData() // IDataContext context)
        {
            var context = new HardcodedContext();
            context.Read();
        }
    }
}
