using System.IO;
using System.Collections.Generic;

namespace HackVirtualMachine
{
    public class FileWriter
    {
        private string filepath;

        public FileWriter(string filepath)
        {
            this.filepath = filepath;
        }

        public void Write(IEnumerable<string> assemblyCommands)
        {
            FileStream fileStream = new FileStream(this.filepath, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                foreach(string assemblyCommand in assemblyCommands)
                {
                    writer.WriteLine(assemblyCommand);
                }
            }
        }
    }
}
