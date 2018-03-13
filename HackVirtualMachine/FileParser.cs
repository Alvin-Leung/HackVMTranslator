using System;
using System.IO;
using System.Collections.Generic;

namespace HackVirtualMachine
{
    static public class FileParser
    {
        static private string commentIndicator = "//";

        static public string[] GetArrayOfVMCommands(string filepath)
        {
            List<string> vmCommands;

            if (File.Exists(filepath))
            {
                vmCommands = ReadVMCommandsToList(filepath);
            }
            else
            {
                throw new Exception("FileParser::FileParser - The specified file does not exist");
            }

            Console.WriteLine(Environment.NewLine + "VM file parsed...");

            return vmCommands.ToArray();
        }

        static private List<string> ReadVMCommandsToList(string filepath)
        {
            List<string> vmCommands = new List<string>();

            string newLine;

            using (StreamReader streamReader = new StreamReader(filepath))
            {
                while (!streamReader.EndOfStream)
                {
                    newLine = streamReader.ReadLine();

                    newLine = RemoveInlineComments(newLine);

                    newLine = RemoveWhitespacePadding(newLine);

                    if (newLine != String.Empty)
                    {
                        vmCommands.Add(newLine);
                    }
                }
            }

            return vmCommands;
        }

        static private string RemoveInlineComments(string line)
        {
            int indexOfCommentStart;

            if (line.Contains(commentIndicator))
            {
                indexOfCommentStart = line.IndexOf(commentIndicator);

                line = line.Remove(indexOfCommentStart);
            }

            return line;
        }

        static private string RemoveWhitespacePadding(string line)
        {
            return line.Trim(' ');
        }
    }
}
