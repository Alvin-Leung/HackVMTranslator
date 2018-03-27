using System;

namespace HackVMTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath;

            if (VMTranslatorConsole.IsCommandLineUsed(args))
            {
                if (VMTranslatorConsole.IsArgumentArrayValid(args))
                {
                    filepath = args[0];
                }
                else
                {
                    if (!VMTranslatorConsole.IsHelpRequested(args))
                    {
                        Console.WriteLine(Environment.NewLine +
                            "Error: HackVMTranslator could not translate the .vm file specified by the filepath input");
                    }

                    VMTranslatorConsole.DisplayCommandLineHelp();

                    return;
                }
            }
            else
            {
                filepath = VMTranslatorConsole.GetValidFilepathFromUser();
            }

            VMTranslator.TryConvertToAsm(filepath);

            VMTranslatorConsole.DisplayExitMessage();
        }
    }
}
