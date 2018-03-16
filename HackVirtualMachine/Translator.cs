namespace HackVirtualMachine
{
    static public class Translator
    {
        static public string[] GetAssemblyCodeFromArithmeticVMCommand(string vmCommand)
        {
            string[] assemblyCodeEquivalentToVMCommand;

            if (vmCommand == "add")
            {
                assemblyCodeEquivalentToVMCommand = new string[] 
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=D+M",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "sub")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=M-D",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "neg")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=-M",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "eq")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=M-D",
                    "@EQUAL",
                    "D;JEQ",
                    "D=0",
                    "@PUSH",
                    "0;JMP",
                    "(EQUAL)",
                    "D=1",
                    "(PUSH)",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "gt")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=M-D",
                    "@GREATERTHAN",
                    "D;JGT",
                    "D=0",
                    "@PUSH",
                    "0;JMP",
                    "(GREATERTHAN)",
                    "D=1",
                    "(PUSH)",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "lt")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=M-D",
                    "@LESSTHAN",
                    "D;JLT",
                    "D=0",
                    "@PUSH",
                    "0;JMP",
                    "(LESSTHAN)",
                    "D=1",
                    "(PUSH)",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "and")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=D&M",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "or")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=D|M",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "not")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=!M",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else
            {
                throw new System.Exception("Arithmetic command '" + vmCommand + "' not recognized");
            }

            return assemblyCodeEquivalentToVMCommand;
        }
    }
}
