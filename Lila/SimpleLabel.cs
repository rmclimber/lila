using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace Lila
{
    public class SimpleLabel
    {
        // instance members
        [Name("name")]
        public string ImgName { get; set; }
        [Name("path")]
        public string ImgPath { get; set; }
        [Name("label")]
        public int Label { get; set; }
        

        // constructor(s)
        public SimpleLabel(string name, string path, string label) 
        {
            ImgName = name;
            ImgPath = path;
            if (int.TryParse(label, out int l)) Label = l;
        }
    }
}
