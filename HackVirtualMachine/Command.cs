namespace HackVirtualMachine
{
    abstract public class Command : ICommand
    {
        protected readonly string vmCommand;

        public Command(string vmCommand)
        {
            this.vmCommand = vmCommand;
        }

        abstract public string[] GetAssemblyCommands();
    }
}
