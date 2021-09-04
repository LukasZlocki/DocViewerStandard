using DocViewerStandard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DocViewerStandard.Services
{
    class IoSettings
    {
        UserSettings userSettings = new UserSettings();
        UserLanguage userLanguageSettings = new UserLanguage();

        // constructor
        public IoSettings()
        {

        }

        // Load settings from file
        public void LoadSettings()
        {
            BinaryReader br;

            try
            {
                br = new BinaryReader(new FileStream("PathSettings.dat", FileMode.Open));
            }

            catch (IOException e)
            {
                MessageBox.Show("Cannot open file - file will be created");
                try
                {
                    FileStream fs = new FileStream("PathSettings.dat", FileMode.Create);
                }
                catch (IOException k)
                {
                    MessageBox.Show("Cannot create file ");
                }

                return;
            }

            try
            {
                userSettings.MatrixFilePath = (br.ReadString());
                userSettings.DocumentFilesPath = (br.ReadString());
                userSettings.MatrixFileName = (br.ReadString());
            }

            catch (IOException e)
            {
                MessageBox.Show("Cannot read from file");
                return;
            }
            br.Close();
        }

        // Save settings to file : PathSettings.dat
        public void SaveSettings(UserSettings settings)
        {
            BinaryWriter bw;

            try
            {
                bw = new BinaryWriter(new FileStream("PathSettings.dat", FileMode.Create));
            }

            catch (IOException e)
            {
                MessageBox.Show("Cannot create file");
                return;
            }

            try
            {
                bw.Write(settings.MatrixFilePath);
                bw.Write(settings.DocumentFilesPath);
                bw.Write(settings.MatrixFileName);
            }

            catch (IOException e)
            {
                MessageBox.Show("Cannot write to file");
                return;
            }
            bw.Close();
        }


        public UserSettings GetUserSettings()
        {
            return userSettings;
        }

    }
}
