using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lila.Properties;

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
            var img = new BitmapImage();
            var memoryStream = new MemoryStream(imageData);
            img.BeginInit();
            img.StreamSource = memoryStream;
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.EndInit();
            img.Freeze();
            ImageViewerMain.Source = img;
        }
    }
}
