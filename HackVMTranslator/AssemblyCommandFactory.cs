using System;
using System.Collections.Generic;

namespace HackVMTranslator
{
    public class AssemblyCommandFactory : IAssemblyCommandFactory
    {
        private Translator translator = new Translator();

        public IEnumerable<string> GetAssemblyCommands(IEnumerable<string> vmCommands)
        {
            IEnumerable<string> nextAssemblyInstructions;

            List<string> assemblyCommands = new List<string>();

            int vmCommandLineNumber = 1;

            try
            {
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

                    vmCommandLineNumber++;
                }

                Console.WriteLine("VM code converted to assembly code...");

                return assemblyCommands;
            }
            catch (Exception e)
            {
                string newErrorMessage = 
                    "Error on line " + vmCommandLineNumber.ToString() + ": " + e.Message;

                throw new Exception(newErrorMessage);
            }
        }
    }
}
