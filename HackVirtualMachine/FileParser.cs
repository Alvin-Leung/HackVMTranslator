using System;
using System.IO;
using System.Collections.Generic;

namespace HackVirtualMachine
{
    public class FileParser
    {
        private List<string> vmCommands = new List<string>();

        private string commentIndicator = "//";

        public FileParser(string filepath)
        {
            if (File.Exists(filepath))
            {
                this.ReadVMCommandsToList(filepath);
            }
            else
            {
                throw new Exception("FileParser::FileParser - The specified file does not exist");
            }
        }

        public string[] GetArrayOfVMCommands()
        {
            return vmCommands.ToArray();
        }

        private void ReadVMCommandsToList(string filepath)
        {
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

            Console.WriteLine(Environment.NewLine + "VM file parsed...");
        }

        private string RemoveInlineComments(string line)
        {
            int indexOfCommentStart;

            if (line.Contains(commentIndicator))
            {
                indexOfCommentStart = line.IndexOf(commentIndicator);

                line = line.Remove(indexOfCommentStart);
            }

            return line;
        }

        private string RemoveWhitespacePadding(string line)
        {
            return line.Trim(' ');
        }
    }
}
