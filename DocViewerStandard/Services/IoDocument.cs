using System.IO;
using System.Windows;

namespace DocViewerStandard.Models
{
    class IoDocument
    {
        UserSettings UserSettings = new UserSettings();

        // constructor
        public IoDocument(UserSettings _userSettings)
        {
            UserSettings = _userSettings;
        }

        // GET - get instruction name
        /// <param name="partNumber">Part number</param>
        /// <param name="instruction">Object Document to store instruction name</param>
        public void GetInstructionName(string partNumber, ref Document instruction)
        {
            string _lineToSplit = "";
            string _instructionName = "";

            LoadLineContainsPartNumber(partNumber, ref _lineToSplit, UserSettings);
            ExtractInstructionNameFromLine(_lineToSplit, ref _instructionName);

            instruction.InstructionName = _instructionName;

        }


        /// <param name="partNumber">string -> part number given bu user</param>
        /// <param name="lineToSplit">string REFERENCE -> line with part number and document name </param>
        /// <param name="userSettings">object -> with user settings like extension of datata base file, path to databasae file, etc.</param>
        private bool LoadLineContainsPartNumber(string partNumber, ref string lineToSplit, UserSettings userSettings)
        {
            string pathMatrix = userSettings.MatrixFilePath + '\\';
            string fileNameMatrix = userSettings.MatrixFileName;

            string _lineToSplit = "";

            bool isPartNumberFind = false;

            try
            {
                using (StreamReader sr = new StreamReader(pathMatrix + fileNameMatrix))
                {

                    do
                    {
                        isPartNumberFind = CheckIfPartNumberPresent(_lineToSplit, partNumber);
                        if (isPartNumberFind == true)
                        {
                            // Importand ! we find the string out :)
                            lineToSplit = _lineToSplit;
                            return true;
                        }
                    } while ((_lineToSplit = sr.ReadLine()) != null);

                }
            }
            catch
            {
                MessageBox.Show("Brak poprawnej sciezki do pliku");
            }
            return false;
        }


        // checking if partNumber is present in string lineToSplit
        private bool CheckIfPartNumberPresent(string lineToSplit, string partNumber)
        {
            bool _isPresent = false;
            _isPresent = lineToSplit.Contains(partNumber);
            return (_isPresent);
        }


        /// <summary>
        /// Extracting document name from line that need to be splited
        /// </summary>
        /// <param name="lineToSplit">string -> string with part number, speparator and document name </param>
        /// <param name="splitedInstructionName">string REFERENCE -> Instruction name to put instruction name after spliting process</param>
        private void ExtractInstructionNameFromLine(string lineToSplit, ref string splitedInstructionName)
        {
            StringExtractor stringExtractor = new StringExtractor(lineToSplit);

            splitedInstructionName = stringExtractor.GetExtractedInstructionName();
        }


    }
}
