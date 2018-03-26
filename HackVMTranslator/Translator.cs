using System;

namespace HackVMTranslator
{
    public class Translator
    {
        private LabelGenerator labelGenerator = new LabelGenerator();

        public string[] GetAssemblyCodeFromArithmeticVMCommand(string vmCommand)
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
                string equalLabel = labelGenerator.GetNextEqualLabel();

                string pushLabel = labelGenerator.GetNextPushLabel();

                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=M-D",
                    "@" + equalLabel,
                    "D;JEQ",
                    "D=0",
                    "@" + pushLabel,
                    "0;JMP",
                    "(" + equalLabel + ")",
                    "D=1",
                    "(" + pushLabel + ")",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "gt")
            {
                string greaterThanLabel = labelGenerator.GetNextGreaterThanLabel();

                string pushLabel = labelGenerator.GetNextPushLabel();

                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=M-D",
                    "@" + greaterThanLabel.ToString(),
                    "D;JGT",
                    "D=0",
                    "@" + pushLabel.ToString(),
                    "0;JMP",
                    "(" + greaterThanLabel + ")",
                    "D=1",
                    "(" + pushLabel + ")",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (vmCommand == "lt")
            {
                string lessThanLabel = labelGenerator.GetNextLessThanLabel();

                string pushLabel = labelGenerator.GetNextPushLabel();

                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@SP",
                    "AM=M-1",
                    "D=M-D",
                    "@" + lessThanLabel,
                    "D;JLT",
                    "D=0",
                    "@" + pushLabel,
                    "0;JMP",
                    "(" + lessThanLabel + ")",
                    "D=1",
                    "(" + pushLabel + ")",
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
                throw new Exception("Arithmetic command '" + vmCommand + "' not recognized");
            }

            return assemblyCodeEquivalentToVMCommand;
        }

        public string[] GetAssemblyCodeFromMemoryAccessVMCommand(string vmCommand)
        {
            string[] assemblyCodeEquivalentToVMCommand;

            string[] splitVMCommand = vmCommand.Split(' ');

            string stackCommand;

            string segment;

            string i;

            int iAsInt;

            if (splitVMCommand.Length == 3)
            {
                stackCommand = splitVMCommand[0];

                segment = splitVMCommand[1];

                i = splitVMCommand[2];

                if (SyntaxValidator.IsConvertableToInteger(i))
                {
                    iAsInt = Convert.ToInt32(i);

                    if (iAsInt > 65535)
                    {
                        throw new Exception("The value parameter cannot be larger than 65535");
                    }
                }
                else
                {
                    throw new Exception("An integer is expected as the last parameter");
                }
            }
            else
            {
                throw new Exception("Memory access command does not have the correct number of arguments");
            }

            assemblyCodeEquivalentToVMCommand = GetAssemblyCode(stackCommand, segment, i);

            return assemblyCodeEquivalentToVMCommand;
        }

        private string[] GetAssemblyCode(string stackCommand, string segment, string i)
        {
            string[] assemblyCodeEquivalentToVMCommand;

            if (
                segment == "local" ||
                segment == "argument" ||
                segment == "this" ||
                segment == "that")
            {
                assemblyCodeEquivalentToVMCommand = TranslateLocalArgumentThisOrThatCommand(stackCommand, segment, i);
            }
            else if (segment == "constant")
            {
                assemblyCodeEquivalentToVMCommand = TranslateConstantCommand(stackCommand, i);
            }
            else if (segment == "static")
            {
                assemblyCodeEquivalentToVMCommand = TranslateStaticCommand(stackCommand, i);
            }
            else if (segment == "temp")
            {
                assemblyCodeEquivalentToVMCommand = TranslateTempCommand(stackCommand, i);
            }
            else if (segment == "pointer")
            {
                assemblyCodeEquivalentToVMCommand = TranslatePointerCommand(stackCommand, i);
            }
            else
            {
                throw new Exception("Memory access command not recognized");
            }

            return assemblyCodeEquivalentToVMCommand;
        }

        private string[] TranslateLocalArgumentThisOrThatCommand(string stackCommand, string segment, string i)
        {
            string[] assemblyCodeEquivalentToVMCommand;

            string targetLabel;

            if (segment == "local")
            {
                targetLabel = "LCL";
            }
            else if (segment == "argument")
            {
                targetLabel = "ARG";
            }
            else if (segment == "this")
            {
                targetLabel = "THIS";
            }
            else if (segment == "that")
            {
                targetLabel = "THAT";
            }
            else
            {
                throw new Exception("Memory access command not recognized");
            }

            if (stackCommand == "push")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@" + i,
                    "D=A",
                    "@" + targetLabel,
                    "D=D+M",
                    "A=D",
                    "D=M",
                    "@SP",
                    "A=M",
                    "M=D",
                    "@SP",
                    "M=M+1"
                };
            }
            else if (stackCommand == "pop")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                    "@" + i,
                    "D=A",
                    "@" + targetLabel,
                    "D=D+M",
                    "@R13",
                    "M=D",
                    "@SP",
                    "AM=M-1",
                    "D=M",
                    "@R13",
                    "A=M",
                    "M=D"
                };
            }
            else
            {
                throw new Exception("Memory access command not recognized");
            }

            return assemblyCodeEquivalentToVMCommand;
        }

        private string[] TranslateConstantCommand(string stackCommand, string i)
        {
            string[] assemblyCodeEquivalentToVMCommand;

            if (stackCommand == "push")
            {
                assemblyCodeEquivalentToVMCommand = new string[]
                {
                        "@" + i,
                        "D=A",
                        "@SP",
                        "A=M",
                        "M=D",
                        "@SP",
                        "M=M+1"
                };
            }
            else if (stackCommand == "pop")
            {
                throw new Exception("Operations of the form 'pop constant i', are not allowed");
            }
            else
            {
                throw new Exception("Memory access command not recognized");
            }

            return assemblyCodeEquivalentToVMCommand;
        }

        private string[] TranslateStaticCommand(string stackCommand, string i)
        {
            string[] assemblyCodeEquivalentToVMCommand;

            if (Convert.ToInt32(i) <= 239)
            {
                if (stackCommand == "push")
                {
                    assemblyCodeEquivalentToVMCommand = new string[]
                    {
                            "@static." + i,
                            "D=M",
                            "@SP",
                            "A=M",
                            "M=D",
                            "@SP",
                            "M=M+1"
                    };
                }
                else if (stackCommand == "pop")
                {
                    assemblyCodeEquivalentToVMCommand = new string[]
                    {
                            "@SP",
                            "AM=M-1",
                            "D=M",
                            "@static." + i,
                            "M=D"
                    };
                }
                else
                {
                    throw new Exception("Memory access command not recognized");
                }
            }
            else
            {
                throw new Exception("Memory access commands for the static memory segment cannot take values greater than 239");
            }

            return assemblyCodeEquivalentToVMCommand;
        }

        private string[] TranslateTempCommand(string stackCommand, string i)
        {
            string[] assemblyCodeEquivalentToVMCommand;

            int tempSegmentStartAddress = 5;

            int targetRAMAddress = tempSegmentStartAddress + Convert.ToInt32(i);

            if (targetRAMAddress <= 12)
            {
                if (stackCommand == "push")
                {
                    assemblyCodeEquivalentToVMCommand = new string[]
                    {
                            "@" + targetRAMAddress.ToString(),
                            "D=M",
                            "@SP",
                            "A=M",
                            "M=D",
                            "@SP",
                            "M=M+1"
                    };
                }
                else if (stackCommand == "pop")
                {
                    assemblyCodeEquivalentToVMCommand = new string[]
                    {
                            "@SP",
                            "AM=M-1",
                            "D=M",
                            "@" + targetRAMAddress.ToString(),
                            "M=D"
                    };
                }
                else
                {
                    throw new Exception("Memory access command not recognized");
                }
            }
            else
            {
                throw new Exception("Memory access commands for the temp memory segment cannot take a parameter value greater than 7");
            }

            return assemblyCodeEquivalentToVMCommand;
        }

        private string[] TranslatePointerCommand(string stackCommand, string i)
        {
            string[] assemblyCodeEquivalentToVMCommand;

            if (i == "0" || i == "1")
            {
                string targetRAMLabel;

                if (i == "0")
                {
                    targetRAMLabel = "THIS";
                }
                else
                {
                    targetRAMLabel = "THAT";
                }

                if (stackCommand == "push")
                {
                    assemblyCodeEquivalentToVMCommand = new string[]
                    {
                            "@" + targetRAMLabel,
                            "D=M",
                            "@SP",
                            "A=M",
                            "M=D",
                            "@SP",
                            "M=M+1"
                    };
                }
                else if (stackCommand == "pop")
                {
                    assemblyCodeEquivalentToVMCommand = new string[]
                    {
                            "@SP",
                            "AM=M-1",
                            "D=M",
                            "@" + targetRAMLabel,
                            "M=D"
                    };
                }
                else
                {
                    throw new Exception("Memory access command not recognized");
                }
            }
            else
            {
                throw new Exception("Memory access commands for the pointer memory segment cannot take values other than 0 or 1");
            }

            return assemblyCodeEquivalentToVMCommand;
        }
    }
}
