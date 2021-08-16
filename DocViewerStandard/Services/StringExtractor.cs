using System;
using System.Windows;

namespace DocViewerStandard.Models
{
    class StringExtractor
    {
        // ToDo : dividing char implement to UserSettings
        static char[] DIVIDING_CHAR = new char[] { ',' };

        private string InstructionName = "";

        // DocLibrary docLibrary = new DocLibrary();


        public StringExtractor(string splitIt)
        {
            SplitItAndExtractIstructionName(splitIt, ref InstructionName);
        }

        private void SplitItAndExtractIstructionName(string toSplit, ref string instructionName)
        {
            try
            {
                // Spliting toSplit string by DIVIDING_CHAR and 
                string[] SplitedArray = toSplit.Split(DIVIDING_CHAR, StringSplitOptions.RemoveEmptyEntries);

                instructionName = SplitedArray[1]; // 0- part number, 1 -> Instruction Name
            }
            catch
            {
                MessageBox.Show("Brak dokumentu w bazie");
            }
        }


        #region Get extracted library methods

        // geting library from Doc Library
        public string GetExtractedInstructionName()
        {
            return InstructionName;
        }

        #endregion
    }

}
