using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Lila
{
    class SimpleOutput
    {
        // core instance members
        // TODO: adjust getters/setters so that mismatch cannot occur
        private List<SimpleLabel> records { get; set; }

        // constructor(s)
        public SimpleOutput() 
        { 
            records = new List<SimpleLabel>();
        }

        // restore an active project from a CSV
        public SimpleOutput(string filename)
        {
            records = GetRecords(filename);
        }

        // Additions
        // get records for an active project from a CSV
        public List<SimpleLabel> GetRecords(string filename)
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader,
                CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<SimpleLabel>().ToList();
            }
        }

        // adds new record
        public void AddRecord(string imgName, string imgPath, string label)
        {
            var record = new SimpleLabel(imgName, imgPath, label);
            records.Append(record);
        }

        // Deletions
        // throws out the whole list
        public void ClearRecords() { records = new List<SimpleLabel>(); }
        
        // deletes and returns last record
        public SimpleLabel DeleteLastRecord()
        {
            var lastRecord = records.ElementAt(records.Count - 1);
            records.RemoveAt(records.Count - 1);
            return lastRecord;
        }

        // Write to csv
        public void ToCsv(string filename)
        {
            // the using block sets up an IDisposable, like Python with block
            using (var writer = new StreamWriter(filename))
                using (var csv = new CsvWriter(writer, 
                    CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(records); // no need to flush due to using
            }
        }
    }
}
