using DocViewerStandard.Models;
using DocViewerStandard.Services;
using System.Windows;


namespace DocViewerStandard
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        UserSettings userSettings = new UserSettings();

        public SettingsWindow()
        {
            InitializeComponent();

            // Loading settings.

            IoSettings settings = new IoSettings();
            settings.LoadSettings();
            userSettings.SetSettings(settings.GetUserSettings());

            UpdateDataOnScreen(userSettings);

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            userSettings.MatrixFilePath = txtPath.Text;
            userSettings.DocumentFilesPath = txtPathDocs.Text;
            userSettings.MatrixFileName = txtFileName.Text;

            // Radio buttons ale already set up !!

            // Savings settings
            IoSettings settings = new IoSettings();
            settings.SaveSettings(userSettings);

            this.Close();
        }

        // Updating text boxes on screen.
        private void UpdateDataOnScreen(UserSettings userSettings)
        {
            txtPath.Text = userSettings.MatrixFilePath;
            txtPathDocs.Text = userSettings.DocumentFilesPath;
            txtFileName.Text = userSettings.MatrixFileName;         
        }



    }
}

