using System;

namespace HackVirtualMachine
{
    public class MemoryAccessCommand : Command, ICommand
    {
        public MemoryAccessCommand(string vmCommand) : base(vmCommand) { }

        public string[] GetAssemblyCommands()
        {
            throw new NotImplementedException();
        }
    }
}
