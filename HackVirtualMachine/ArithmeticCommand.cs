namespace HackVirtualMachine
{
    public class ArithmeticCommand : Command
    {
        public ArithmeticCommand(string vmCommand) : base(vmCommand) { }

        public override string[] GetAssemblyCommands()
        {
            return translator.GetAssemblyCodeFromArithmeticVMCommand(this.vmCommand);
        }
    }
}
