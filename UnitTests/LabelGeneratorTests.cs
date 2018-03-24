using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackVMTranslator;

namespace UnitTests
{
    [TestClass]
    public class LabelGeneratorTests
    {
        private LabelGenerator labelGenerator = new LabelGenerator();

        [TestMethod]
        public void GetNextPushLabel_GetNextPushLabel1000Times_PushLabelsShouldBeAppendedWithIncrementingIntegers()
        {
            string nextPushLabel;

            string expectedPushLabel;

            for (int i=0; i<1000; i++)
            {
                nextPushLabel = labelGenerator.GetNextPushLabel();

                expectedPushLabel = "PUSH." + i.ToString();

                Assert.AreEqual(expectedPushLabel, nextPushLabel);
            }
        }

        [TestMethod]
        public void GetNextEqualLabel_GetNextEqualLabel1000Times_EqualLabelsShouldBeAppendedWithIncrementingIntegers()
        {
            string nextEqualLabel;

            string expectedEqualLabel;

            for (int i = 0; i < 1000; i++)
            {
                nextEqualLabel = labelGenerator.GetNextEqualLabel();

                expectedEqualLabel = "EQUAL." + i.ToString();

                Assert.AreEqual(expectedEqualLabel, nextEqualLabel);
            }
        }

        [TestMethod]
        public void GetNextGreaterThanLabel_GetNextGreaterThanLabel1000Times_GreaterThanLabelsShouldBeAppendedWithIncrementingIntegers()
        {
            string nextGreaterThanLabel;

            string expectedGreaterThanLabel;

            for (int i = 0; i < 1000; i++)
            {
                nextGreaterThanLabel = labelGenerator.GetNextGreaterThanLabel();

                expectedGreaterThanLabel = "GREATERTHAN." + i.ToString();

                Assert.AreEqual(expectedGreaterThanLabel, nextGreaterThanLabel);
            }
        }

        [TestMethod]
        public void GetLessThanThanLabel_GetNextLessThanLabel1000Times_LessThanLabelsShouldBeAppendedWithIncrementingIntegers()
        {
            string nextLessThanLabel;

            string expectedLessThanLabel;

            for (int i = 0; i < 1000; i++)
            {
                nextLessThanLabel = labelGenerator.GetNextLessThanLabel();

                expectedLessThanLabel = "LESSTHAN." + i.ToString();

                Assert.AreEqual(expectedLessThanLabel, nextLessThanLabel);
            }
        }
    }
}
