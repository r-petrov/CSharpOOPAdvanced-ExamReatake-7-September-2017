using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
