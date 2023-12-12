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
        private IEnumerable<string> extensions;
        public FileNavigator()
        {
            imageFilter = CreateImageFilter();
            extensions = CreateImageExtensions();
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
                var filenames = RecurseEnumerateFiles(dlg.FileName);
                if (filenames.Count() > 0)
                {

                    foreach (var filename in filenames)
                    {
                        Console.WriteLine(filename);
                    }
                }
                else
                {
                    Console.WriteLine("no dice");
                }
                return filenames;

            }
            return null;
        }

        // creates an IEnumerable<string> to check file extensions
        private IEnumerable<string> CreateImageExtensions()
        {
            IEnumerable<string> exts = new List<string>();
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (var codec in codecs)
            {
                exts = exts.Union(codec.FilenameExtension.ToLower().Replace("*", "").Split(";"));
            }

            foreach (var ext in exts)
            {
                Console.WriteLine(ext);
            }
            return exts;
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
                Console.WriteLine(codec.FilenameExtension);
            }

            imageFilter = FormatFilterString(imageFilter, sep, "All Files", "*.*");
            Console.WriteLine(imageFilter);
            return imageFilter;
        }

        // enumerate files and recurse subdirs
        private IEnumerable<string> RecurseEnumerateFiles(string path)
        {
            EnumerationOptions options = new EnumerationOptions();
            var result = new List<string>();
            options.RecurseSubdirectories = true;
            
            // get all files
            var filenames = Directory.EnumerateFiles(path, "*.*", options);
            Console.WriteLine(filenames.Count());

            foreach (var filename in filenames)
            {
                Console.WriteLine(String.Format("{0} -- {1}", filename, Path.GetExtension(filename.ToLower())));
                string currentExt = Path.GetExtension(filename.ToLower());
                foreach (string ext in extensions)
                {
                    Console.WriteLine(String.Format("{0} {1} {2}", ext, currentExt, currentExt == ext));
                }
                Console.WriteLine(extensions.Any(ext => ext.Trim() == currentExt.Trim()).ToString());
                break;
            }

            // filter with lambda function
            filenames = filenames.Where(
                s => extensions.Any(
                    ext => ext == Path.GetExtension(s.ToLower())));
            Console.WriteLine(filenames.Count());

            foreach (var filename in filenames)
            {
                Console.WriteLine(filename);
                result.Add(filename);
            }
            return result;
        }

        // Simplify format syntax for filter string
        private string FormatFilterString(
            string filter,
            string sep,
            string codecName,
            string extension)
        {
            return String.Format("{0}{1}{2} ({3})|{3}",
                filter,
                sep,
                codecName,
                extension);
        }
    }
}
