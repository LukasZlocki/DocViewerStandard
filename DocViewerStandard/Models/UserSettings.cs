using System.IO;
using System.Windows;

namespace DocViewerStandard.Models
{
    class UserSettings
    {
        public string MatrixFilePath { get; set; }
        public string MatrixFileName { get; set; }
        public string DocumentFilesPath { get; set; }
        public string DocumentFileExtension = ".jpg";


        public void SetSettings(UserSettings settings)
        {
            this.MatrixFilePath = settings.MatrixFilePath;
            this.MatrixFileName = settings.MatrixFileName;
            this.DocumentFilesPath = settings.DocumentFilesPath;
        }


        /*

        // Load settings from file
        public void LoadSettings(ref UserSettings settings)
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
                settings.MatrixFilePath = (br.ReadString());
                settings.DocumentFilesPath = (br.ReadString());
                settings.MatrixFileName = (br.ReadString());
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

        */



    }
}
