using System;
using System.Collections.Generic;

namespace HackVirtualMachine
{
    public class AssemblyCommandFactory : IAssemblyCommandFactory
    {
        private Translator translator = new Translator();

        public IEnumerable<string> GetAssemblyCommands(IEnumerable<string> vmCommands)
        {
            IEnumerable<string> nextAssemblyInstructions;

            List<string> assemblyCommands = new List<string>();

            foreach (string vmCommand in vmCommands)
            {
                if (SyntaxValidator.IsArithmeticVMCommand(vmCommand))
                {
                    nextAssemblyInstructions = translator.GetAssemblyCodeFromArithmeticVMCommand(vmCommand);
                }
                else if (SyntaxValidator.IsMemoryAccessVMCommand(vmCommand))
                {
                    nextAssemblyInstructions = translator.GetAssemblyCodeFromMemoryAccessVMCommand(vmCommand);
                }
                else
                {
                    throw new Exception("Unrecognized virtual machine command");
                }

                assemblyCommands.AddRange(nextAssemblyInstructions);
            }

            return assemblyCommands;
        }
    }
}
