using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManyConsole;

namespace VcfReader
{
    class Program
    {
        public static int Main(string[] args)
        {
            var commands = ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));

            return ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);
        }
    }
}
