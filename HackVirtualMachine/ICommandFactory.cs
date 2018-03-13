namespace HackVirtualMachine
{
    interface ICommandFactory
    {
        ICommand GetCommand(string vmCommand);
    }
}
