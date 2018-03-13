namespace HackVirtualMachine
{
    abstract public class Command
    {
        protected readonly string vmCommand;

        protected Command(string vmCommand)
        {
            this.vmCommand = vmCommand;
        }
    }
}
