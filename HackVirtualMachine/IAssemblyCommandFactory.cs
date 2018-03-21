using System.Collections.Generic;

namespace HackVirtualMachine
{
    interface IAssemblyCommandFactory
    {
        IEnumerable<string> GetAssemblyCommands(IEnumerable<string> vmCommands);
    }
}
