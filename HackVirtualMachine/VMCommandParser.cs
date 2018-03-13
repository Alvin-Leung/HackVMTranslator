using System.Collections.Generic;

namespace HackVirtualMachine
{
    public class VMCommandParser
    {
        private CommandFactory commandFactory = new CommandFactory();

        public ICommand[] GetCommands(string[] vmCommands)
        {
            List<ICommand> commands = new List<ICommand>();

            ICommand currentCommand;

            foreach (string vmCommand in vmCommands)
            {
                currentCommand = commandFactory.GetCommand(vmCommand);

                commands.Add(currentCommand);
            }

            return commands.ToArray();
        }
    }
}
