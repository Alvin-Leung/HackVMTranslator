using System;

namespace HackVirtualMachine
{
    public class ArithmeticCommand : Command, ICommand
    {
        public ArithmeticCommand(string vmCommand) : base(vmCommand) { }

        public string[] GetAssemblyCommands()
        {
            throw new NotImplementedException();
        }
    }
}
