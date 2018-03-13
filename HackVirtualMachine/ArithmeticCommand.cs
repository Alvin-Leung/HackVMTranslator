using System;
using System.Collections.Generic;

namespace HackVirtualMachine
{
    public class ArithmeticCommand : Command, ICommand
    {
        protected override List<string> assemblyCommands { get; set; }

        public string[] GetAssemblyCommands()
        {
            throw new NotImplementedException();
        }
    }
}
