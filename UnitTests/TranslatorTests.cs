using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackVMTranslator;

namespace UnitTests
{
    [TestClass]
    public class TranslatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputMultiplyCommand_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("multiply");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputDivisionCommand_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("divide");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputAdditionCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("add");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputSubtractionCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("sub");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputNegationCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("neg");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputEqualityCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("eq");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputGreaterThanCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("gt");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputLessThanCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("lt");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputAndCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("and");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputOrCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("or");
        }

        [TestMethod]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputNotCommand_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("not");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromArithmeticVMCommand_InputWeirdCommand_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromArithmeticVMCommand("45%12234jhdf");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputCommandWith1Argument_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputCommandWith2Arguments_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push constant");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputPopConstantCommand_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("pop constant 23");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputCommandWithUndefinedMemorySegment_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push undefinedMemorySegment 23");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputCommandWithValueParameterThatCannotBeConvertedToInteger_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push constant five");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputCommandWithValueParameterOver65535_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push constant 65536");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputLocalCommandWithInvalidStackInstruction_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("plop local 5");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputConstantCommandWithInvalidStackInstruction_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("plop constant 20");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputStaticCommandWithInvalidStackInstruction_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("plop static 20");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputTempCommandWithInvalidStackInstruction_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("plop temp 20");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputPointerCommandWithInvalidStackInstruction_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("plop pointer 0");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputStaticCommandWithValueParameterJustOver239_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push static 240");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputStaticCommandWithValueParameterOver239_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("pop static 2500");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputTempCommandWithValueParameterJustOver7_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push temp 8");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputTempCommandWithValueParameterOver7_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push temp 201");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputPointerCommandWithValueParameterNotOneOrZero_ThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push pointer 2");
        }

        [TestMethod]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputValidPushLocalCommands_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push local 0");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push local 100");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push local 65535");
        }

        [TestMethod]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputValidPopArgumentCommands_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push argument 0");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push argument 100");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push argument 65535");
        }

        [TestMethod]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputValidPushThisCommands_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push this 0");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push this 100");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push this 65535");
        }

        [TestMethod]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputValidPopThatCommands_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push that 0");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push that 100");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push that 65535");
        }

        [TestMethod]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputValidPushConstantCommands_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push constant 0");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push constant 100");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push constant 65535");
        }

        [TestMethod]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputValidPushStaticCommands_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push argument 0");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push argument 100");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push argument 239");
        }

        [TestMethod]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputValidPushTempCommands_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push temp 0");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push temp 3");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push temp 7");
        }

        [TestMethod]
        public void GetAssemblyCodeFromMemoryAccessVMCommand_InputValidPushPointerCommands_DoNotThrowException()
        {
            Translator translator = new Translator();

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push pointer 0");

            translator.GetAssemblyCodeFromMemoryAccessVMCommand("push pointer 1");
        }
    }
}
