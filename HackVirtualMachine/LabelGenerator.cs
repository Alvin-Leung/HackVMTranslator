namespace HackVirtualMachine
{
    public class LabelGenerator
    {
        private int pushLabelCount = 0;

        private int greaterThanLabelCount = 0;

        private int lessThanLabelCount = 0;

        private int equalLabelCount = 0;

        public string GetNextPushLabel()
        {
            string pushLabel = "PUSH." + pushLabelCount.ToString();

            pushLabelCount++;

            return pushLabel;
        }

        public string GetNextGreaterThanLabel()
        {
            string greaterThanLabel = "GREATERTHAN." + greaterThanLabelCount.ToString();

            greaterThanLabelCount++;

            return greaterThanLabel;
        }

        public string GetNextLessThanLabel()
        {
            string lessThanLabel = "LESSTHAN." + lessThanLabelCount.ToString();

            lessThanLabelCount++;

            return lessThanLabel;
        }

        public string GetNextEqualLabel()
        {
            string equalLabel = "EQUAL." + equalLabelCount.ToString();

            equalLabelCount++;

            return equalLabel;
        }
    }
}
