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
        // backing fields
        private string _ImgName;
        private string _ImgPath;
        private string _Label;

        // properties
        [Name("name")]
        public string ImgName 
        { 
            get { return _ImgName; }
            set
            {
                if (value.Length > 0) _ImgName = value;
                else throw new ArgumentException();
            }
        }

        [Name("path")]
        public string ImgPath
        {
            get { return _ImgPath; }
            set
            {
                if (value.Length > 0) _ImgPath = value;
                else throw new ArgumentException();
            }
        }

        [Name("label")]
        public string Label
        {
            get { return _Label; }
            set
            {
                if (int.TryParse(value, out int l)) _Label = value;
                else throw new ArgumentException();
            }
        }


        // constructor(s)
        public SimpleLabel(string name, string path, string label) 
        {
            ImgName = name;
            Console.WriteLine("imgname written");
            ImgPath = path;
            Console.WriteLine("imgpath written");
            Label = label;
            Console.WriteLine("label written");

        }
    }
}
