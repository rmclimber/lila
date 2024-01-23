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
    public class FileNavigator
    {
        private string imageFilter;
        private string dir;
        private IEnumerable<string> extensions;
        public FileNavigator()
        {
            extensions = CreateImageExtensions();
        }

        /*
         * Return all images as as a FilesFound object.
         */
        internal FilesFound GetFiles()
        {
            IEnumerable<string> filenames = ListFiles();
            FilesFound ff = new FilesFound(dir, filenames);
            return ff;
        }

        /*
         * List all image files in a parent directory and its child directories 
         */
        internal IEnumerable<string> ListFiles()
        {
            // set up dialog box 
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.IsFolderPicker = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // set parent dir
                dir = dlg.FileName;

                // inform user
                MessageBox.Show("You selected: " + dir);

                // get all image files, searching subdirectories
                var filenames = RecurseEnumerateFiles(dlg.FileName);
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
            return exts;
        }

        // enumerate files and recurse subdirs
        private IEnumerable<string> RecurseEnumerateFiles(string path)
        {
            EnumerationOptions options = new EnumerationOptions();
            var result = new List<string>();
            options.RecurseSubdirectories = true;
            
            // get all files
            var filenames = Directory.EnumerateFiles(path, "*.*", options);

            // filter with lambda function
            filenames = filenames.Where(
                s => extensions.Any(
                    ext => ext == Path.GetExtension(s.ToLower())));

            foreach (var filename in filenames)
            {
                Console.WriteLine("Adding: " + filename);
                result.Add(filename);
            }
            return result;
        }
    }
}
