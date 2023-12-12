using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lila
{
    internal class FilesFound
    {
        public IEnumerable<string> fullFilenames { get; set; }
        public IEnumerable<string> truncFilenames { get; set; }

        public FilesFound(string dir, IEnumerable<string> filenames)
        {
            fullFilenames = filenames;
            truncFilenames = TruncateFilenames(dir, filenames);
        }

        private IEnumerable<string> TruncateFilenames(
            string dir, 
            IEnumerable<string> filenames)
        {
            var output = new List<string>();
            foreach (var filename in filenames)
            {
                output.Add(filename.Replace(dir + "\\", string.Empty));
            }
            return output;
        }
    }
}
