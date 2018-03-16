using System;

namespace HackVirtualMachine
{
    public class MemoryAccessCommand : Command
    {
        public MemoryAccessCommand(string vmCommand) : base(vmCommand) { }

        public override string[] GetAssemblyCommands()
        {
            throw new NotImplementedException();
        }
    }
}
