﻿using DocViewerStandard.Models;
using DocViewerStandard.Services;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DocViewerStandard
{
    /// <summary>
    /// docViewerStandard
    /// lzlocki
    /// AD 2019 - 2020
    /// Version : 2.0 Standard 
    /// </summary>
    public partial class MainWindow : Window
    { 
        // user settings for matrix / documents paths / language
        UserSettings GlobalUserSettings = new UserSettings();
        UserLanguage userLanguageSettings = new UserLanguage();

        public MainWindow()
        {
            InitializeComponent();

            // Loading user settings 
            IoSettings settings = new IoSettings();
            settings.LoadSettings();

            //Set global settings
            GlobalUserSettings.SetSettings(settings.GetUserSettings());
        }


        #region Buttons

        private void btnLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (btnLanguage.Content == FindResource("PL"))
            {
                btnLanguage.Content = FindResource("UA");
                userLanguageSettings.SetToUkraineLanguage();
            }
            else
            {
                btnLanguage.Content = FindResource("PL");
                userLanguageSettings.SetToPolishLanguage();
            }
            // Refresh document on screen
            MainLoop();
        }

        #endregion

        #region OnEnterHandler
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                MainLoop();
            }
        }

        #endregion

         
        private void MainLoop()
        {
            // Object with name of the document 
            Document Instruction = new Document();
            // 
            string _partNumber = "";
            _partNumber = txtBoxID.Text;

            // loading documentation from file
            LoadDocuments(_partNumber, ref Instruction, GlobalUserSettings);

            // Show instruction on screen
            ShowInstructionOnScreen(Instruction);
        }

        #region Preparing documents from file

        /// <summary>
        /// load documents for partNumber and store it in docLibrary 
        /// </summary>
        /// <param name="partNumber"> string with part number </param>
        /// <param name="instructionName"> class to store instruction name </param>
        /// <param name="userSettings"> class with user settings parameters </param>
        private void LoadDocuments(string partNumber, ref Document instructionName, UserSettings userSettings)
        {
            IoDocument doc = new IoDocument(userSettings);

            // Retriving instruction from database.
            doc.GetInstructionName(partNumber, ref instructionName);
        }

        #endregion

        #region Showing documents

        private void ShowInstructionOnScreen(Document instruction)
        {

            ShowThisDocumentOnScreen(instruction.InstructionName, GlobalUserSettings);

        }

        /// <summary>
        /// Showing document on screen
        /// </summary>
        /// <param name="documentName"> name of the file with proper document</param>
        /// <param name="userSettings"> paths of document, its file extension </param>
        private void ShowThisDocumentOnScreen(string documentName, UserSettings userSettings)
        {
            // if language set to UA additional file extansion need to be added to read Ukrainian docs.
            if (userLanguageSettings.isPolishLanguageOn() == false)
            {
                documentName = documentName + "_UA";
            }

            string fullPath = userSettings.DocumentFilesPath + "\\" + documentName + userSettings.DocumentFileExtension;

            try
            {
                ImageSource imagesource = new BitmapImage(new Uri(fullPath));
                ImageShow.Source = imagesource;
            }
            catch
            {
                if (documentName == "")
                {
                    ShowFailDocument("FALSE_NO_FILE_WITH_DOCUMENT", userSettings);
                }

            }
        }

        /// <summary>
        /// Showing emergency document like "no code number" or "No document" 
        /// </summary>
        /// <param name="mode"> mode of error to use proper page </param>
        /// <param name="userSettings"> paths of document, its file extension </param>
        void ShowFailDocument(string mode, UserSettings userSettings)
        {
            string path = "";

            if (mode == "FALSE_NO_PART_NB")
            {
                //   MessageBox.Show(" ! Brak kodu w bazie ! ");
                path = userSettings.DocumentFilesPath + "\\" + "BrakKodu.jpg";
                ImageSource imagesource = new BitmapImage(new Uri(path));
                ImageShow.Source = imagesource;

            }

            if (mode == "FALSE_NO_FILE_WITH_DOCUMENT")
            {
                MessageBox.Show(" ! Brak dokumentu w bazie ! ");
                path = userSettings.DocumentFilesPath + "\\" + "BrakDokumentu.jpg";
                ImageSource imagesource = new BitmapImage(new Uri(path));
                ImageShow.Source = imagesource;
            }
        }

        #endregion


        #region Menu Iteam

        private void SettingsWindowRun(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }







        #endregion


    }
}
