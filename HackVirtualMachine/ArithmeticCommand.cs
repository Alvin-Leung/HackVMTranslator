namespace HackVirtualMachine
{
    public class ArithmeticCommand : Command
    {
        public ArithmeticCommand(string vmCommand) : base(vmCommand) { }

        public override string[] GetAssemblyCommands()
        {
            return Translator.GetAssemblyCodeFromArithmeticVMCommand(this.vmCommand);
        }
    }
}
