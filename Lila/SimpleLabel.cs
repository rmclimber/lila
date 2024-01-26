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
        public string ImgName 
        { 
            get { return ImgName; }
            set
            {
                if (value.Length > 0) ImgName = value;
                else throw new ArgumentException();
            }
        }

        [Name("path")]
        public string ImgPath
        {
            get { return ImgPath; }
            set
            {
                if (value.Length > 0) ImgPath = value;
                else throw new ArgumentException();
            }
        }

        [Name("label")]
        public string Label
        {
            get { return Label; }
            set
            {
                if (int.TryParse(value, out int l)) Label = value;
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
