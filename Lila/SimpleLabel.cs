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
        [Name("name")]
        public string ImgName { get; set; }
        [Name("path")]
        public string ImgPath { get; set; }
        [Name("label")]
        public int Label { get; set; }
    }
}
