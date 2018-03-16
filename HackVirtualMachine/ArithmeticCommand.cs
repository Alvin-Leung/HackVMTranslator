using System;

namespace HackVirtualMachine
{
    public class ArithmeticCommand : Command, ICommand
    {
        public ArithmeticCommand(string vmCommand) : base(vmCommand) { }

        public string[] GetAssemblyCommands()
        {
            return Translator.GetAssemblyCodeFromArithmeticVMCommand(this.vmCommand);
        }
    }
}
