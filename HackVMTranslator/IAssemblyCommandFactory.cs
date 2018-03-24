using System.Collections.Generic;

namespace HackVMTranslator
{
    interface IAssemblyCommandFactory
    {
        IEnumerable<string> GetAssemblyCommands(IEnumerable<string> vmCommands);
    }
}
