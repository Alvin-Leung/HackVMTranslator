using System;
using System.IO;

namespace HackVMTranslator
{
    static public class VMTranslatorConsole
    {
        static public string GetValidFilepathFromUser()
        {
            string userInput;

            bool isValidFilepath;

            do
            {
                Console.Write("VM code filepath (.vm): ");

                userInput = Console.ReadLine();

                isValidFilepath = IsValidFilepath(userInput);

                if (!isValidFilepath)
                {
                    if (IsHelpRequested(userInput))
                    {
                        DisplayRuntimeHelp();
                    }
                    else
                    {
                        Console.WriteLine(
                            Environment.NewLine +
                            "Filepath is not valid. " + Environment.NewLine +
                            "Please check that the file exists and that it is a .vm file." + Environment.NewLine);
                    }
                }
            }
            while (!isValidFilepath);

            Console.WriteLine();

            return userInput;
        }

        static public void DisplayCommandLineHelp()
        {
            string newLine = Environment.NewLine;

            Console.WriteLine(
                newLine +
                "Usage: HackVMTranslator [filepath]" + newLine +
                newLine +
                "Options:" + newLine +
                "\tfilepath\t\tThe filepath to an .vm file" + newLine +
                newLine
                );

            ExplainExpectedProgramOutputs();
        }

        static public void DisplayExitMessage()
        {
            Console.WriteLine();

            Console.WriteLine("Press enter to exit...");

            Console.ReadLine();
        }

        static public bool IsCommandLineUsed(string[] args)
        {
            if (args.Length >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool IsArgumentArrayValid(string[] args)
        {
            return IsValidNumberOfArguments(args) && IsValidFilepath(args[0]);
        }

        static public bool IsHelpRequested(string[] args)
        {
            if (args.Length == 1)
            {
                return IsHelpRequested(args[0]);
            }
            else
            {
                return false;
            }
        }

        static private void DisplayRuntimeHelp()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);

            string version = fileVersionInfo.FileVersion;

            Console.WriteLine(
                Environment.NewLine +
                "HackVMTranslator v" + version + Environment.NewLine);

            ExplainExpectedProgramOutputs();

            Console.WriteLine();
        }

        static private void ExplainExpectedProgramOutputs()
        {
            Console.WriteLine(
                "As input, the HackVMTranslator program expects a filepath to a .vm file. " +
                "It converts virtual machine code contained in the .vm file to assembly code contained in an .asm file. " +
                "The .asm file will be created in the folder of the .vm file and will take the name of the .vm file. " +
                "At translation time, if there is an .asm file with the same filename in the folder, it will be overwritten.");
        }

        static private bool IsHelpRequested(string userInput)
        {
            if (userInput == "/?" ||
                userInput == "-h" ||
                userInput == "-help" ||
                userInput == "--help" ||
                userInput == "help")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static private bool IsValidNumberOfArguments(string[] args)
        {
            if (args.Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static private bool IsValidFilepath(string filepath)
        {
            bool isValid;

            if (File.Exists(filepath))
            {
                if (IsFileVM(filepath))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }

        static private bool IsFileVM(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);

            string expectedInputFileExtension = ".vm";

            bool fileIsVM;

            if (fileInfo.Extension != expectedInputFileExtension)
            {
                fileIsVM = false;
            }
            else
            {
                fileIsVM = true;
            }

            return fileIsVM;
        }
    }
}
