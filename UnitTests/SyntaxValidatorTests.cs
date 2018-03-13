﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackVirtualMachine;

namespace UnitTests
{
    [TestClass]
    public class SyntaxValidatorTests
    {
        [TestMethod]
        public void IsArithmeticVMCommand_InputAddCommand_ReturnsTrue()
        {
            string vmCommand = "add";

            bool isArithmeticVMCommand = SyntaxValidator.IsArithmeticVMCommand(vmCommand);

            Assert.AreEqual(true, isArithmeticVMCommand);
        }

        [TestMethod]
        public void IsArithmeticVMCommand_InputSubtractCommand_ReturnsTrue()
        {
            string vmCommand = "sub";

            bool isArithmeticVMCommand = SyntaxValidator.IsArithmeticVMCommand(vmCommand);

            Assert.AreEqual(true, isArithmeticVMCommand);
        }

        [TestMethod]
        public void IsArithmeticVMCommand_InputInvalidAdditionCommand_ReturnsFalse()
        {
            string vmCommand = "addition";

            bool isArithmeticVMCommand = SyntaxValidator.IsArithmeticVMCommand(vmCommand);

            Assert.AreEqual(false, isArithmeticVMCommand);
        }

        [TestMethod]
        public void IsArithmeticVMCommand_InputCommandWithSpace_ReturnsFalse()
        {
            string vmCommand = "    gt";

            bool isArithmeticVMCommand = SyntaxValidator.IsArithmeticVMCommand(vmCommand);

            Assert.AreEqual(false, isArithmeticVMCommand);
        }

        [TestMethod]
        public void IsArithmeticVMCommand_InputRandomSymbolsAndNumbers_ReturnsFalse()
        {
            string vmCommand = "%^$&432*^%231324";

            bool isArithmeticVMCommand = SyntaxValidator.IsArithmeticVMCommand(vmCommand);

            Assert.AreEqual(false, isArithmeticVMCommand);
        }

        [TestMethod]
        public void IsMemoryAccessVMCommand_InputValidPushConstantCommand_ReturnsTrue()
        {
            string vmCommand = "push constant 909";

            bool isMemoryAccessVMCommand = SyntaxValidator.IsMemoryAccessVMCommand(vmCommand);

            Assert.AreEqual(true, isMemoryAccessVMCommand);
        }

        [TestMethod]
        public void IsMemoryAccessVMCommand_InputValidPopStaticCommand_ReturnsTrue()
        {
            string vmCommand = "pop static 200";

            bool isMemoryAccessVMCommand = SyntaxValidator.IsMemoryAccessVMCommand(vmCommand);

            Assert.AreEqual(true, isMemoryAccessVMCommand);
        }

        [TestMethod]
        public void IsMemoryAccessVMCommand_InputInvalidPopConstantCommand_ReturnsFalse()
        {
            string vmCommand = "pop constant 200";

            bool isMemoryAccessVMCommand = SyntaxValidator.IsMemoryAccessVMCommand(vmCommand);

            Assert.AreEqual(false, isMemoryAccessVMCommand);
        }

        [TestMethod]
        public void IsMemoryAccessVMCommand_InputInvalidPushCommand_ReturnsFalse()
        {
            string vmCommand = "push stack 245";

            bool isMemoryAccessVMCommand = SyntaxValidator.IsMemoryAccessVMCommand(vmCommand);

            Assert.AreEqual(false, isMemoryAccessVMCommand);
        }

        [TestMethod]
        public void IsMemoryAccessVMCommand_InputPushTempCommandWithoutValue_ReturnsFalse()
        {
            string vmCommand = "push temp";

            bool isMemoryAccessVMCommand = SyntaxValidator.IsMemoryAccessVMCommand(vmCommand);

            Assert.AreEqual(false, isMemoryAccessVMCommand);
        }
    }
}