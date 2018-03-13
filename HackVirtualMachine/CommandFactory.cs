using System;

namespace HackVirtualMachine
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand GetCommand(string vmCommand)
        {
            ICommand command;

            if (SyntaxValidator.IsArithmeticVMCommand(vmCommand))
            {
                command = new ArithmeticCommand(vmCommand);
            }
            else if (SyntaxValidator.IsMemoryAccessVMCommand(vmCommand))
            {
                command = new MemoryAccessCommand(vmCommand);
            }
            else
            {
                throw new Exception("Unrecognized command");
            }

            return command;
        }
    }
}
