using System;
using System.IO;
using System.Collections.Generic;

namespace HackVMTranslator
{
    public static class VMTranslator
    {
        public static void TryConvertToAsm(string filepath)
        {
            try
            {
                ConvertToAsm(filepath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ConvertToAsm(string filepath)
        {
            FileParser fileParser = new FileParser();

            IEnumerable<string> vmCommands = fileParser.GetVMCommands(filepath);

            AssemblyCommandFactory assemblyCommandFactory = new AssemblyCommandFactory();

            IEnumerable<string> assemblyCommands = assemblyCommandFactory.GetAssemblyCommands(vmCommands);

            string outputFilepath = Path.Combine(Path.GetDirectoryName(filepath), Path.GetFileNameWithoutExtension(filepath) + ".asm");

            FileWriter fileWriter = new FileWriter(outputFilepath);

            fileWriter.Write(assemblyCommands);
        }
    }
}
