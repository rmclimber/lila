using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Lila
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // class members
        FilesFound ff;
        FileNavigator navigator;

        // constructor
        public MainWindow()
        {
            InitializeComponent();
            navigator = new FileNavigator();
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

        private void Display_Selected(object sender, RoutedEventArgs e)
        {
            byte[] imageData;
            var currentIndex = FileListBox.SelectedIndex;
            string filename = ff.fullFilenames.ElementAt(currentIndex);
            var uri = new Uri(filename);
            ImageViewerMain.Source = new BitmapImage(uri);
            //FileStream stream = new FileStream(filename,
            //    FileMode.Open, FileAccess.Read);
            //stream.Close();

        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ff = navigator.GetFiles();
            FileListBox.ItemsSource = ff.truncFilenames;

        }
    }
}
