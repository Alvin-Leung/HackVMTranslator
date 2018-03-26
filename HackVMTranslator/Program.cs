using System;
using System.Collections.Generic;

namespace HackVMTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileParser fileParser = new FileParser();

                string filepath =
                    @"C:\Users\Alvin\Desktop\Programming\Teach_Yourself_CS\Computer_Architecture\nand2tetris\projects\07\StackArithmetic\StackTest\StackTest.vm";

                IEnumerable<string> vmCommands = fileParser.GetVMCommands(filepath);

                AssemblyCommandFactory assemblyCommandFactory = new AssemblyCommandFactory();

                IEnumerable<string> assemblyCommands = assemblyCommandFactory.GetAssemblyCommands(vmCommands);

                FileWriter fileWriter = new FileWriter(@"C:\Users\Alvin\Desktop\Programming\Teach_Yourself_CS\Computer_Architecture\nand2tetris\projects\07\StackArithmetic\StackTest\StackTest.asm");

                fileWriter.Write(assemblyCommands);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Virtual machine code translation successful");

                Console.ReadLine();
            }
        }
    }
}
