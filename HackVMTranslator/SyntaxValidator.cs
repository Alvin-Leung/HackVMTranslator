using System.Text.RegularExpressions;

namespace HackVMTranslator
{
    static public class SyntaxValidator
    {
        static private Regex arithmeticCommandRegex = new Regex(
            @"^(add|sub|neg|eq|gt|lt|and|or|not)$");

        static private Regex memoryAccessCommandRegex = new Regex(
            @"(^(push|pop)\s+(local|argument|this|that|static|pointer|temp)\s+\d+$)|(^push\s+constant\s+\d+$)");

        static private Regex integerRegex = new Regex(@"^\d+$");

        static public bool IsArithmeticVMCommand(string vmCommand)
        {
            return arithmeticCommandRegex.IsMatch(vmCommand);
        }

        static public bool IsMemoryAccessVMCommand(string vmCommand)
        {
            return memoryAccessCommandRegex.IsMatch(vmCommand);
        }

        static public bool IsConvertableToInteger(string i)
        {
            return integerRegex.IsMatch(i);
        }
    }
}
