using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W4_SOLID_OCP.Models;

namespace W4_SOLID_OCP.Services
{
    public interface IFileManager
    {
        string[] ReadFile();
        void WriteFile(List<Character> characters);
    }
}
