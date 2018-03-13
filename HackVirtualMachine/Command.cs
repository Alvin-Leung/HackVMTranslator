using System.Collections.Generic;

namespace HackVirtualMachine
{
    abstract public class Command
    {
        abstract protected List<string> assemblyCommands { get; set; }
    }
}
