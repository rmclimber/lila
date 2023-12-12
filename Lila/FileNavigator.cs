using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lila
{
    internal class FileNavigator
    {
        private string imageFilter;
        public FileNavigator()
        {
            imageFilter = CreateImageFilter();
        }

        /*
         * Limit 
         */
        internal IEnumerable<string> ListFiles()
        {
            // set up dialog box 
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.IsFolderPicker = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected: " + dlg.FileName);

                // get all files, including subdirectories
                return RecurseEnumerateFiles(dlg.FileName);

            }
            return null;
        }

        // Creates a string which can be used as a dialog file type filter
        private string CreateImageFilter()
        {
            // cribbed from https://stackoverflow.com/a/9176575 
            // get codecs 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // build filter string
            string sep = string.Empty;
            string imageFilter = "";
            foreach (var codec in codecs) 
            {
                // Clean codec name for addition to filter
                Console.WriteLine(codec.CodecName);
                string codecName = 
                    codec.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                Console.WriteLine(codecName);

                // Add to filter
                imageFilter = FormatFilterString(imageFilter, sep, codecName, codec.FilenameExtension);
                sep = "|";
            }

            imageFilter = FormatFilterString(imageFilter, sep, "All Files", "*.*");
            return imageFilter;
        }

        // enumerate files and recurse subdirs
        private IEnumerable<string> RecurseEnumerateFiles(string path)
        {
            EnumerationOptions options = new EnumerationOptions();
            options.RecurseSubdirectories = true;
            return Directory.EnumerateFiles(path, imageFilter, options);
        }

        // Simplify format syntax for filter string
        private string FormatFilterString(
            string filter,
            string sep,
            string codecName,
            string extension)
        {
            return String.Format("{0}{1}{2} ({3}){3}",
                filter,
                sep,
                codecName,
                extension);
        }
    }
}
