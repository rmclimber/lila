using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Lila
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BitmapImage BytesToImage(byte[] imageData)
        {
            var img = new BitmapImage();
            var memoryStream = new MemoryStream(imageData);
            img.BeginInit();
            img.StreamSource = memoryStream;
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.EndInit();
            img.Freeze();
            return img;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageData;
            if (LeftButton.IsChecked == true)
            {
                imageData = Properties.Resources.cougar;
            }
            else
            {
                imageData = Properties.Resources.redcougar;
            }

            ImageViewerMain.Source = BytesToImage(imageData);
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.IsFolderPicker = true;
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected: " + dlg.FileName);
            }

        }
    }
}
