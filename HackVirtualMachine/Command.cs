namespace HackVirtualMachine
{
    abstract public class Command : ICommand
    {
        protected readonly Translator translator = new Translator();

        protected readonly string vmCommand;

        public Command(string vmCommand)
        {
            this.vmCommand = vmCommand;
        }

        abstract public string[] GetAssemblyCommands();
    }
}