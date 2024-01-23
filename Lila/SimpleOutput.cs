using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lila
{
    class SimpleOutput
    {
        // core instance members
        // TODO: adjust getters/setters so that mismatch cannot occur
        private IEnumerable<string> imgNames { get; set; }
        private IEnumerable<string> imgPaths { get; set; }
        private IEnumerable<string> labels { get; set; }

        // constructor(s)
        public SimpleOutput() 
        { 
            imgNames = new List<string>();
            imgPaths = new List<string>();
            labels = new List<string>();
        }

        public void AddLabel(string imgName, string imgPath, string label)
        {
            imgNames.Append(imgName);
            imgPaths.Append(imgPath);
            labels.Append(label);
        }

        public void ToCsv(string filename)
        {

        }
    }
}
